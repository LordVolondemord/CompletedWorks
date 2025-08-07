import {
    CommentsUI,
    DotsUI
} from "/KonvaUI.js";
import {
    DotsApiCalls,
    CommentsApiCalls,
} from "/APICalls.js";
import { ContextMenu, ContextUIComments } from "./ContextUI.js";

export class DotsCallbacks {
    static async addDot() {
        let dotDataObj = {
            x: document.getElementById("addXInput").value,
            y: document.getElementById("addYInput").value,
            radius: document.getElementById("addRadiusInput").value,
            color: document.getElementById("addColorInput").value,
        }

        const aPIResult = await DotsApiCalls.addDot(dotDataObj);
        if (!aPIResult) {
            alert("Cant add dot.".concat(" Api error!"));
            return false;
        }
        dotDataObj.id = aPIResult;
        const uIResult = new DotsUI().addDot(dotDataObj);
        if (!uIResult) {
            alert("Cant add dot.".concat(" UI error!"));
            return false;
        }
        return true;
    }
    static async editDot() {
        let id = document.getElementById("currentElementId").value;
        let dotDataObj = {};
        if (document.getElementById("editXInput").value.trim() != "") {
            dotDataObj.x = document.getElementById("editXInput").value
        }

        if (document.getElementById("editYInput").value.trim() != "") {
            dotDataObj.y = document.getElementById("editYInput").value
        }

        if (document.getElementById("editRadiusInput").value.trim() != "") {
            dotDataObj.radius = document.getElementById("editRadiusInput").value
        }

        if (document.getElementById("editColorInput").value.trim() != "") {
            dotDataObj.color = document.getElementById("editColorInput").value
        }
        const aPIResult = await DotsApiCalls.editDotById(id, dotDataObj);
        if (!aPIResult) {
            alert("Cant edit dot.".concat(" Api error!"));
            return false;
        }
        const uIResult = new DotsUI().editDot(id, dotDataObj); 
        if (!uIResult) {
            alert("Cant edit dot.".concat(" UI error!"));
            return false;
        }
        return true;
    }
    static async removeDot() {
        let id = document.getElementById("currentElementId").value;
        const aPIResult = await DotsApiCalls.removeDotById(id);
        if (!aPIResult) {
            alert("Cant delete dot with id: ".concat(id).concat(" Api error!"));
            return false;
        }
        const uIResult = new DotsUI().removeDot(id); 
        if (!uIResult) {
            alert("Cant delete dot with id: ".concat(id).concat(" UI error!"));
            return false;
        }
        return true;
    }
}

export class CommentsCallbacks {
    static async addComment() {

        let id = document.getElementById("currentElementId").value;
        let commentDataObj = {
            text: document.getElementById("addTextInput").value,
            color: document.getElementById("addColorInput").value,
        }
        const aPIResult = await CommentsApiCalls.addCommentByDotId(id, commentDataObj)
        if (!aPIResult) {
            alert("Cant add comment.".concat(" Api error!"));
            return false;
        }
        commentDataObj.id = aPIResult;
        const uIResult = new CommentsUI().addComment(id, commentDataObj);
        if (!uIResult) {
            alert("Cant add comment.".concat(" UI error!"));
            return false;
        }
        return true;
    }
    static async editComment() {
        
        let id = document.getElementById("currentElementId").value;
        let commentDataObj = {
            text: document.getElementById("editTextInput").value,
            color: document.getElementById("editColorInput").value,
        }
        ContextUIComments.editFormDestroy();
        const aPIResult = await CommentsApiCalls.editCommentById(id, commentDataObj);
        if (!aPIResult) {
            alert("Cant edit comment.".concat(" Api error!"));
            return false;
        }
        const uIResult = new CommentsUI().editComment(id, commentDataObj);
        if (!uIResult) {
            alert("Cant edit comment.".concat(" UI error!"));
            return false;
        }
        return true;
    }
    static async removeComment() {
        let id = document.getElementById("currentElementId").value;
        const aPIResult = await CommentsApiCalls.removeCommentById(id);
        if (!aPIResult) {
            alert("Cant delete comment with id: ".concat(id).concat(" Api error!"));
            return false;
        }

        const uIResult = new CommentsUI().removeComment(id);
        if (!uIResult) {
            alert("Cant delete comment with id: ".concat(id).concat(" UI error!"));
            return false;
        }
        return true;
    }
    static async clearComments() {
        ContextMenu.clearMenu();
        let id = document.getElementById("currentElementId").value;
        const aPIResult = await CommentsApiCalls.removeCommentsByDotId(id);
        if (!aPIResult) {
            alert("Cant clear comments with id: ".concat(id).concat(" Api error!"));
            return false;
        }

        const uIResult = new CommentsUI().clearComments(id);
        if (!uIResult) {
            alert("Cant clear comments with id: ".concat(id).concat(" UI error!"));
            return false;
        }
        return true;
    }
}

export class CanvasLoader {
    static async loadOnCanvas() {
        const aPIDotsResult = await DotsApiCalls.getDots();
        if (!aPIDotsResult) {
            alert("Cant load dots on canvas.".concat(" Api error!"));
            return false;
        }

        for (let i = 0; i < aPIDotsResult.length; i++) {
            const dotId = aPIDotsResult[i].id;

            const aPIDotCommentsResult = await CommentsApiCalls.getCommentsByDotId(dotId);
            if (!aPIDotCommentsResult) {
                alert("Cant load dot comments on canvas.".concat(" Api error!"));
                return false;
            }

            new DotsUI().addDot(aPIDotsResult[i], aPIDotCommentsResult);

        }
    }
}

