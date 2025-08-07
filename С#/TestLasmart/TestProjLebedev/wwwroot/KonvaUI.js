import { ContextMenu } from "/ContextUI.js";
import {
    DotsCallbacks,
    CommentsCallbacks
} from "/Callbacks.js";
import {
    ContextUIDots,
    ContextUIComments,
    ContextElements
} from "/ContextUI.js";
import { DotsApiCalls, CommentsApiCalls } from "./APICalls.js";
let commentsUIInstance = null;
export class CommentsUI {
    constructor(stageObj = undefined, layerObj = undefined) {
        if (commentsUIInstance) {
            return commentsUIInstance;
        }
        commentsUIInstance = this;
        this.stage = stageObj;
        if (stageObj == undefined) {
            this.stage = new Konva.Stage({
                container: 'container',
                width: window.innerWidth,
                height: window.innerHeight,
            });

            this.stage.on("click", function (evt) {
                if (evt.target.getClassName() === "Stage") {
                    if (ContextElements.someContextElementExists()) {
                        ContextElements.cleanContextElements();
                    }
                    else {
                        let pointerPosition = evt.target.getPointerPosition();
                        document.getElementById("currentElementId").dataset.x = pointerPosition.x;
                        document.getElementById("currentElementId").dataset.y = pointerPosition.y;
                        ContextUIDots.addFormCreate();
                    }
                }
            });
        }
        this.layer = layerObj
        if (layerObj == undefined) {
            this.layer = new Konva.Layer();
        }

        

        this.stage.add(this.layer)
    };
    getGroupById(id) {
        let foundGroup = this.layer.find(".groupId".concat(id));
        if (foundGroup.length !== 1) {
            return false;
        }
        return foundGroup[0];
    }
    getCommentById(id) {
        let foundComment = this.layer.find(".commentId".concat(id.toString()));
        if (foundComment.length !== 1) {
            return false;
        }
        return foundComment[0];
    }

    getCommentsByDotId(dotId) {
        let foundGroup = this.getGroupById(dotId);
        if (!foundGroup) {
            return false;
        }

        let comments = foundGroup.getChildren(function (node) {
            return node.getClassName() === "Text";
        })
        return comments
    }


    addComment(dotId, commentObj) {
        let foundDot = new DotsUI().getDotById(dotId);
        if (!foundDot) {
            return false;
        }

        let foundGroup = this.getGroupById(dotId);
        if (!foundGroup) {
            return false;
        }

        let foundComments = this.getCommentsByDotId(dotId);
        if (!foundComments) {
            return false;
        }

        const commentHeight = 30;
        let commentsYPosition = foundDot.y() + foundDot.radius() + commentHeight * foundComments.length;

        const text = new Konva.Text({
            name: "commentId" + commentObj.id,
            x: foundDot.x(),
            y: commentsYPosition,
            text: commentObj.text,
            fontSize: 18,
            fontFamily: 'Calibri',
            fill: '#' + commentObj.color,
            height: commentHeight,
            align: 'center'
        });
        text.setAttrs({
            x: text.x() - (text.width() / 2)
        });

        text.on("pointerclick tap", async function (evt) {
            if (ContextElements.someContextElementExists()) {
                ContextElements.cleanContextElements();
            }
            let contextMenuItems = new Map([
                ["edit", ContextUIComments.editFormCreate],
                ["remove", CommentsCallbacks.removeComment],
            ])

            let id = evt.currentTarget.name().replace("commentId", "");
            document.getElementById("currentElementId").value = id;
            let currentTargetPosition = evt.currentTarget.absolutePosition();
            ContextMenu.createMenu(id, currentTargetPosition.x, currentTargetPosition.y, contextMenuItems);
        })

        foundGroup.add(text);
        return true;
    }
    addComments(dotId, commentsDataObjsArray) {
        let foundDot = new DotsUI().getDotById(dotId);
        if (!foundDot) {
            return false;
        }

        let foundGroup = this.layer.find(".groupId".concat(dotId));
        if (foundGroup.length !== 1) {
            return false;
        }
        foundGroup = foundGroup[0];

        let foundComments = this.getCommentsByDotId(dotId);
        if (!foundComments) {
            return false;
        }

        for (let i = 0; i < commentsDataObjsArray.length; i++) {
            this.addComment(dotId, commentsDataObjsArray[i]);
        }
        return true;

    }
    refreshCommentsPositionsToDot(dotId) {
        let foundDot = new DotsUI().getDotById(dotId);
        if (!foundDot) {
            return false;
        }

        let foundGroup = this.layer.find(".groupId".concat(dotId));
        if (foundGroup.length !== 1) {
            return false;
        }
        foundGroup = foundGroup[0];

        let foundComments = this.getCommentsByDotId(dotId);
        if (!foundComments) {
            return false;
        }

        const commentHeight = 30;
        let commentsYPosition = foundDot.y() + foundDot.radius();
        for (let i = 0; i < foundComments.length; i++) {
            foundComments[i].setAttrs({
                x: foundDot.x() - (foundComments[i].width() / 2),
                y: commentsYPosition
            })

            foundGroup.add(foundComments[i]);

            commentsYPosition += commentHeight;
        }
        return true;
    }
    editComment(commentId, commentDataObj) {
        let foundComment = this.getCommentById(commentId);
        if (!foundComment) {
            return false;
        }

        foundComment.setAttrs({
            text: "text" in commentDataObj ? commentDataObj.text : foundComment.x(),
            fill: "color" in commentDataObj ? "#".concat(commentDataObj.color) : foundComment.fill(),
        });

        this.refreshCommentsPositionsToDot(commentId);
        return true;

    }
    removeComment(commentId) {
        let foundComment = this.getCommentById(commentId);
        if (!foundComment) {
            return false;
        }
        let parentGroup = foundComment.getParent();
        let dotId = parentGroup.getChildren(function (node) {
            return node.getClassName() === 'Circle';
        })[0].name().replace("dotId", "")

        foundComment.destroy();

        this.refreshCommentsPositionsToDot(dotId);
        return true;
    }
    removeComments(dotId) {
        let getedComments = this.getCommentsByDotId(dotId);
        if (!getedComments) {
            return false
        }

        for (let i = 0; i < getedComments.length; i++) {
            getedComments[i].destroy();
        }

        return true;
    }
    clearComments(dotId) {
        let getedComments = this.getCommentsByDotId(dotId);
        if (!getedComments) {
            return false
        }

        for (let i = 0; i < getedComments.length; i++) {
            getedComments[i].destroy();
        }
        return true;
    }
}

let dotsUIInstance = null;
export class DotsUI {
    constructor(stageObj = undefined, layerObj = undefined) {
        if (dotsUIInstance) {
            return dotsUIInstance
        }
        dotsUIInstance = this;
        this.stage = stageObj;
        if (stageObj == undefined) {
            this.stage = new Konva.Stage({
                container: 'container',
                width: window.innerWidth,
                height: window.innerHeight,
            });

            this.stage.on("click", function (evt) {
                if (evt.target.getClassName() === "Stage") {
                    if (ContextElements.someContextElementExists()) {
                        ContextElements.cleanContextElements();
                    }
                    else {
                        let pointerPosition = evt.target.getPointerPosition();
                        document.getElementById("currentElementId").dataset.x = pointerPosition.x;
                        document.getElementById("currentElementId").dataset.y = pointerPosition.y;
                        ContextUIDots.addFormCreate();
                    }
                }
            })
        }
        this.layer = layerObj
        if (layerObj == undefined) {
            this.layer = new Konva.Layer();
        }
          
        this.stage.add(this.layer)
    };

    getDotById(id) {
        let foundDot = this.layer.find(".dotId".concat(id));
        if (foundDot.length !== 1) {
            return false;
        }
        return foundDot[0];
    }
    getGroupById(id) {
        let foundGroup = this.layer.find(".groupId".concat(id.toString()));
        if (foundGroup.length !== 1) {
            return false;
        }
        return foundGroup[0];
    }

    addDot(dotDataObj, commentsDataObjsArray = []) {
        const group = new Konva.Group({
            name: "groupId".concat(dotDataObj.id),
            draggable: true,
        });

        group.on("dragend", async function (evt) {
            let id = evt.currentTarget.name().replace("groupId", "");
            document.getElementById("currentElementId").value = id
            let currentDot = evt.target.find(".dotId".concat(id))[0];
            let currentDotPosition = currentDot.absolutePosition();
            const aPIResult = await DotsApiCalls.editDotById(id, { x: currentDotPosition.x, y: currentDotPosition.y });
            if (!aPIResult) {
                alert("Cant move dot with id: ".concat(id).concat(" Api error!"));
                return false;
            }
        })

        const circle = new Konva.Circle({
            name: "dotId" + dotDataObj.id,
            x: dotDataObj.x,
            y: dotDataObj.y,
            radius: dotDataObj.radius,
            fill: "#" + dotDataObj.color,
        });

       
        circle.on("pointerclick tap", async function (evt) {
            if (ContextElements.someContextElementExists()) {
                ContextElements.cleanContextElements();
            }

            evt.cancelBubble = true;
            let contextMenuItems = new Map([
                ["edit", ContextUIDots.editFormCreate],
                ["remove", DotsCallbacks.removeDot],
                ["addComment", ContextUIComments.addFormCreate],
                ["clearComments", CommentsCallbacks.clearComments],
            ])

            let id = evt.currentTarget.name().replace("dotId", "");
            document.getElementById("currentElementId").value = id;
            let currentTargetPosition = evt.currentTarget.absolutePosition();
            ContextMenu.createMenu(id, currentTargetPosition.x, currentTargetPosition.y, contextMenuItems);
        });

        circle.on("dblclick dbltap", async function (evt) {
            if (ContextElements.someContextElementExists()) {
                ContextElements.cleanContextElements();
            }

            evt.cancelBubble = true;
            ContextMenu.clearMenu();
            document.getElementById("currentElementId").value = evt.currentTarget.name().replace("dotId", "")
            let uIResult = await DotsCallbacks.removeDot();
        });

        group.add(circle);

        this.layer.add(group)
        if (commentsDataObjsArray.length > 0) {
            new CommentsUI().addComments(dotDataObj.id, commentsDataObjsArray);
        }
        return true
    }

    editDot(id, dotDataObj) {
        let foundDot = this.getDotById(id);
        if (!foundDot) {
            return false;
        }

        foundDot.setAttrs({
            x: "x" in dotDataObj ? dotDataObj.x : foundDot.x(),
            y: "y" in dotDataObj ? dotDataObj.y : foundDot.x(),
            radius: "radius" in dotDataObj ? dotDataObj.radius : foundDot.radius(),
            fill: "color" in dotDataObj ? "#".concat(dotDataObj.color) : foundDot.fill()
        });

        new CommentsUI().refreshCommentsPositionsToDot(id)
        return true;
    }

    removeDot(id) {
        let foundGroup = this.getGroupById(id);
        if (!foundGroup) {
            return false;
        }

        foundGroup.destroy();
        return true;
    }

}

//export let dotsUII = new DotsUI()
//export let commentsUII = new CommentsUI(dotsUII.stage, dotsUII.layer)

//dotsUII.addDot(
//    { id: 1, x: 500, y: 500, radius: 150, color: "00d9d5" },
//    [{ id: 1, text: "haha", color: "111213" },
//    { id: 2, text: "hihi", color: "101010" },
//    { id: 3, text: "hoho", color: "123456" }
//    ]);
//dotsUII.editDot("1", { x: 100, y: 100, color: "d300eb", radius: 50 });


//commentsUIInstance.removeComment("2");
//console.log(commentsUII.getCommentsByDotId("1"))
//commentsUIInstance.clearComments("1");
//dotsUIInstance.removeDot(1);