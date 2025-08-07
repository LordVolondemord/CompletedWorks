import {
    DotsUI,
    CommentsUI
}
    from "/KonvaUI.js";
import {
    DotsCallbacks,
    CommentsCallbacks,
    CanvasLoader
} from "/Callbacks.js";
import "/ContextUI.js";

let dotsUII = new DotsUI()
let commentsUII = new CommentsUI(dotsUII.stage, dotsUII.layer)
CanvasLoader.loadOnCanvas();
