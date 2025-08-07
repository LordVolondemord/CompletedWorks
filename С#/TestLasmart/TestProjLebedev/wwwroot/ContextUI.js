import {
    DotsCallbacks,
    CommentsCallbacks
} from "./Callbacks.js";

export class ContextMenu {
    static contextMenuExists() {
        if (document.getElementById("contextMenu")) {
            return true;
        }
        return false;
    }

    static createMenu(elemid, x, y, liAndCallbacksMap) {
        ContextMenu.clearMenu();
        document.getElementById("currentElementId").value = elemid;
        document.getElementById("currentElementId").dataset.x = x;
        document.getElementById("currentElementId").dataset.y = y;
        let contextMenu = document.createElement("div");
        contextMenu.id = "contextMenu";
        let ul = document.createElement("ul");
        for (const [itemText, callbackFunc] of liAndCallbacksMap) {
            let li = document.createElement("li")
            li.textContent = itemText;
            li.onclick = callbackFunc;
            ul.appendChild(li);
        }
        contextMenu.appendChild(ul);
        document.body.appendChild(contextMenu);
        document.getElementById("contextMenu").style.left = x.toString().concat("px");
        document.getElementById("contextMenu").style.top = y.toString().concat("px");

    }

    static removeMenu() {
        document.getElementById("contextMenu").remove()
    }

    static clearMenu() {
        if (ContextMenu.contextMenuExists()) {
            ContextMenu.removeMenu();
        }
    }
}
export class ContextForm {
    static createForm(formId, fildsIdsArr, comfirmCallback, cancelCallback) {
        ContextMenu.clearMenu();
        let x = document.getElementById("currentElementId").dataset.x;
        let y = document.getElementById("currentElementId").dataset.y;
        let form = document.createElement("form");
        form.id = formId;
        form.style.display = "block";
        form.style.position = "absolute";
        form.style.top = x.concat("px");
        form.style.left = y.concat("px");
        form.style.width = "400px";
        for (let i = 0; i < fildsIdsArr.length; i++) {
            let elem = document.createElement("input");
            elem.id = fildsIdsArr[i];
            elem.style.display = "block";
            elem.placeholder = fildsIdsArr[i],
            elem.type = "text";
            form.appendChild(elem);
        }
        let confirmButton = document.createElement("button");
        confirmButton.type = "button";
        confirmButton.innerText = "Подтвердить";
        confirmButton.onclick = comfirmCallback;
        form.appendChild(confirmButton);

        let cancelButton = document.createElement("button");
        cancelButton.innerText = "Отменить";
        cancelButton.onclick = cancelCallback;
        form.appendChild(cancelButton);
        document.body.appendChild(form);
    }
    static removeForm(formId) {
        document.getElementById(formId).remove();
    }
}

export class ContextUIDots {
    static addFormCreate() {
        ContextForm.createForm("addForm", ["addXInput", "addYInput", "addRadiusInput", "addColorInput"], DotsCallbacks.addDot, ContextUIDots.addFormDestroy);
    };
    static addFormDestroy() {
        ContextForm.removeForm("addForm");
    };

    static editFormCreate() {
        ContextForm.createForm("editForm", ["editXInput", "editYInput", "editRadiusInput", "editColorInput"], DotsCallbacks.editDot, ContextUIDots.editFormDestroy);
    }
    static editFormDestroy() {
        ContextForm.removeForm("editForm");
    };
}

export class ContextUIComments {
    static addFormCreate() {
        ContextForm.createForm("addForm", ["addTextInput", "addColorInput"], CommentsCallbacks.addComment, ContextUIComments.addFormDestroy);
    };
    static addFormDestroy() {
        ContextForm.removeForm("addForm");
    };

    static editFormCreate() {
        ContextForm.createForm("editForm", ["editTextInput", "editColorInput"], CommentsCallbacks.editComment, ContextUIComments.editFormDestroy);
    }
    static editFormDestroy() {
        ContextForm.removeForm("editForm");
    };
}

export class ContextElements {
    static getDefaultContextElementsIdsArray() {
        return [
            "contextMenu",
            "addForm",
            "editForm"
        ]
    }

    static cleanElementById(id) {
        if (document.getElementById(id)) {
            document.getElementById(id).remove()
        }
    };
    static contextElementExists(id) {
        if (document.getElementById(id)) {
            return true;
        }
        return false;
    };

    static someContextElementExists(idsArr = ContextElements.getDefaultContextElementsIdsArray()) {
        for (let i = 0; i < idsArr.length; i++) {
            if (document.getElementById(idsArr[i])) {
                return true;
            }
        };
        return false;
    };

    static cleanContextElements(idsArr = ContextElements.getDefaultContextElementsIdsArray()) {
        for (let i = 0; i < idsArr.length; i++) {
            ContextElements.cleanElementById(idsArr[i]);
        };
        return false;
    }
}