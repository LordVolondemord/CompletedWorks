export class DotsApiCalls {
    static async getDots() {
        let result;
        try {
            await $.ajax({
                url: '/api/dots',
                method: 'get',
                dataType: 'json',
                timeout: 1000,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }
    static async getDotById(id) {
        let result;
        try {
            await $.ajax({
                url: '/api/dots/' + id,
                method: 'get',
                dataType: 'json',
                timeout: 1000,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }

    static async addDot(dotDataObj) {
        let result;
        let bodyData = {};
        if ("x" in dotDataObj) {
            bodyData.x = dotDataObj.x;
        }
        if ("y" in dotDataObj) {
            bodyData.y = dotDataObj.y;
        }
        if ("radius" in dotDataObj) {
            bodyData.radius = dotDataObj.radius;
        }
        if ("color" in dotDataObj) {
            bodyData.color = dotDataObj.color;
        }

        try {
            await $.ajax({
                url: '/api/dots',
                method: 'post',
                dataType: 'json',
                timeout: 1000,
                data: bodyData,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }

        return result;
    }

    static async editDotById(id, dotDataObj) {
        let result;
        let bodyData = {};
        if ("x" in dotDataObj) {
            bodyData.x = dotDataObj.x;
        }
        if ("y" in dotDataObj) {
            bodyData.y = dotDataObj.y;
        }
        if ("radius" in dotDataObj) {
            bodyData.radius = dotDataObj.radius;
        }
        if ("color" in dotDataObj) {
            bodyData.color = dotDataObj.color;
        }
        try {
            await $.ajax({
                url: '/api/dots/' + id,
                method: 'put',
                dataType: 'json',
                timeout: 1000,
                data: bodyData,
                success: function (data) {
                    result = true;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }
    static async removeDotById(id) {
        if (isNaN(parseInt(id))) {
            return false
        }
        let result;
        try {
            await $.ajax({
                url: '/api/dots/' + id,
                method: 'delete',
                //dataType: 'json',
                timeout: 1500,
                success: function (data) {
                    result = true;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch (err) {
            result = false
        }
        finally {
            return result;
        }

    }
};

export class CommentsApiCalls {
    static async getCommentsByDotId(dotId) {
        let result;
        try {
            await $.ajax({
                url: '/api/dots/'.concat(dotId).concat("/comments"),
                method: 'get',
                dataType: 'json',
                timeout: 1000,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }
    static async getCommentById(id) {
        let result;
        try {
            await $.ajax({
                url: '/api/comments/' + id,
                method: 'get',
                dataType: 'json',
                timeout: 1000,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }
    static async addCommentByDotId(dotId, commentDataObj) {
        let result;
        let bodyData = {};

        bodyData.dotId = dotId;
        if ("text" in commentDataObj) {
            bodyData.text = commentDataObj.text;
        }
        if ("color" in commentDataObj) {
            bodyData.color = commentDataObj.color;
        }

        try {
            await $.ajax({
                url: '/api/comments',
                method: 'post',
                dataType: 'json',
                timeout: 1000,
                data: bodyData,
                success: function (data) {
                    result = data;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }

        return result;
    }
    static async editCommentById(id, commentDataObj) {
        let result;
        let bodyData = {};
        if ("text" in commentDataObj) {
            bodyData.text = commentDataObj.text;
        }
        if ("color" in commentDataObj) {
            bodyData.color = commentDataObj.color;
        }
        try {
            await $.ajax({
                url: '/api/comments/' + id,
                method: 'put',
                dataType: 'json',
                timeout: 1000,
                data: bodyData,
                success: function (data) {
                    result = true;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch {
            result = false;
        }
        return result;
    }
    static async removeCommentById(id) {
        if (isNaN(parseInt(id))) {
            return false
        }
        let result;
        try {
            await $.ajax({
                url: '/api/comments/' + id,
                method: 'delete',
                timeout: 1500,
                success: function (data) {
                    result = true;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch (err) {
            result = false;
        }
        finally {
            return result;
        }
    }

    static async removeCommentsByDotId(dotId) {
        if (isNaN(parseInt(dotId))) {
            return false
        }
        let result;
        try {
            await $.ajax({
                url: '/api/dots/'.concat(dotId).concat("/comments"),
                method: 'delete',
                timeout: 1500,
                success: function (data) {
                    result = true;
                },
                error: function (xhr, status) {
                    result = false
                },
            });
        }
        catch (err) {
            result = false;
        }
        finally {
            return result;
        }
    }
    

}
//let resultGetsDot = await DotsApiCalls.getDots();
//console.log("resultGetsDot:", resultGetsDot);

//let resultGetDot = await DotsApiCalls.getDotById("2")
//console.log("resultGetDot:", resultGetDot);

//let resultPostDot = await DotsApiCalls.addDot({ x: 500, y: 500, radius: 150, color: "00d9d5" })
//console.log("resultPostDot:", resultPostDot);

//let resultEditDot = await DotsApiCalls.editDotById("2", { radius: 400, color: "333333" });
//console.log("resultEditDot: ", resultEditDot);

//let resultRemoveDot = await DotsApiCalls.removeDotById(8);
//console.log("resultRemoveDot: ", resultRemoveDot);


//let resultGetsComment = await CommentsApiCalls.getCommentsByDotId(1);
//console.log("resultGetsComment:", resultGetsComment);

//let resultGetComment = await CommentsApiCalls.getCommentById(1)
//console.log("resultGetComment:", resultGetComment);

//let resultPostComment = await CommentsApiCalls.addCommentByDotId(1,{text:"aaaaaaaa", color: "00d9d5" })
//console.log("resultPostComment:", resultPostComment);

//let resultEditComment = await CommentsApiCalls.editCommentById(1, { text: "fffffff", color: "001122" });
//console.log("resultEditComment: ", resultEditComment);

//let resultRemoveComment = await CommentsApiCalls.removeCommentById(8);
//console.log("resultRemoveComment: ", resultRemoveComment);