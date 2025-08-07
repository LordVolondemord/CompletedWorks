using System.Text.Json;
using System.Text.RegularExpressions;
using TestProjLebedev.db;

namespace TestProjLebedev.api
{
    public static class Comments
    {
        public static void addEndpoints(WebApplication app)
        {
            app.MapGet("/api/comments", (DB db, HttpResponse response) => {
                db.Database.EnsureCreated();
                response.ContentType = "application/json";
                return JsonSerializer.Serialize(db.Comments.ToList());
            });

            app.MapGet("/api/dots/{dotId}/comments", (string dotId, DB db, HttpResponse response) => {
                bool correctId = int.TryParse(dotId, out int dotIdValue);
                if (!(correctId && dotIdValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }
                db.Database.EnsureCreated();

                var targetDot = db.Dots.FirstOrDefault(d => d.id == dotIdValue);
                if (targetDot == null)
                {
                    response.StatusCode = 404;
                    return "Dot not found";
                }

                var targetComments = db.Comments.Where(c => c.dotId == dotIdValue);

                response.ContentType = "application/json";
                return JsonSerializer.Serialize(targetComments);
            });


            app.MapGet("/api/comments/{id}", (string id, DB db, HttpRequest request, HttpResponse response) => {
                bool correctId = int.TryParse(id, out int idValue);
                if (!(correctId && idValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }
                db.Database.EnsureCreated();

                var commentData = db.Comments.FirstOrDefault(d => d.id == idValue);
                if (commentData == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }

                response.ContentType = "application/json";
                return JsonSerializer.Serialize(commentData);
            });

            app.MapPost("/api/comments", (DB db, HttpRequest request, HttpResponse response) => {
                db.Database.EnsureCreated();
                try
                {
                    request.Form.ToDictionary();
                }
                catch (System.InvalidOperationException e)
                {
                    response.StatusCode = 400;
                    return "Incorrect body";
                }
                var paramsDict = request.Form.ToDictionary();


                if (
                    !(paramsDict.ContainsKey("dotId") &&
                    paramsDict.ContainsKey("text") &&
                    paramsDict.ContainsKey("color")
                    )
                )
                {
                    response.StatusCode = 400;
                    return "Incorrect post keys!";
                }

                if (!(int.TryParse(paramsDict["dotId"], out int dotId) && dotId >= 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect x key value!";
                }

                if (!Regex.Match(paramsDict["color"], @"^[0-9a-fA-f]{6}$").Success)
                {
                    response.StatusCode = 400;
                    return "Incorrect color key value!";
                }

                var targetDot = db.Dots.FirstOrDefault(d => d.id == dotId);
                if (targetDot == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }
                Comment comment = new Comment { dotId = dotId, color = paramsDict["color"], text = paramsDict["text"] };
                db.Comments.Add(comment);
                db.SaveChanges();
                return comment.id.ToString();
            });

            app.MapPut("/api/comments/{id}", (string id, DB db, HttpRequest request, HttpResponse response) => {
                bool correctId = int.TryParse(id, out int idValue);
                if (!(correctId && idValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }

                db.Database.EnsureCreated();
                try
                {
                    request.Form.ToDictionary();
                }
                catch (System.InvalidOperationException e)
                {
                    response.StatusCode = 400;
                    return "Incorrect body";
                }
                var paramsDict = request.Form.ToDictionary();

                var targetComment = db.Comments.FirstOrDefault(d => d.id == idValue);
                if (targetComment == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }

                if (paramsDict.ContainsKey("color") && !String.IsNullOrEmpty(paramsDict["color"]))
                {
                    if (!Regex.Match(paramsDict["color"], @"^[0-9a-fA-f]{6}$").Success)
                    {
                        response.StatusCode = 400;
                        return "Incorrect color key value!";
                    }
                    targetComment.color = paramsDict["color"];
                }

                if (paramsDict.ContainsKey("text") && !String.IsNullOrEmpty(paramsDict["text"]))
                {
                    
                    targetComment.text = paramsDict["text"];
                }

                db.SaveChanges();
                response.ContentType = "application/json";
                return JsonSerializer.Serialize(targetComment); ;
            });

            app.MapDelete("/api/comments/{id:int}", (string id, DB db, HttpResponse response) => {
                bool correctId = int.TryParse(id, out int idValue);
                if (!(correctId && idValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }

                db.Database.EnsureCreated();

                var targetComment = db.Comments.FirstOrDefault(d => d.id == idValue);
                if (targetComment == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }

                db.Comments.Remove(targetComment);
                db.SaveChanges();
                return "Delete";
            });

            app.MapDelete("/api/dots/{dotId}/comments", (string dotId, DB db, HttpResponse response) => {
                bool correctId = int.TryParse(dotId, out int dotIdValue);
                if (!(correctId && dotIdValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }
                db.Database.EnsureCreated();

                var targetDot = db.Dots.FirstOrDefault(d => d.id == dotIdValue);
                if (targetDot == null)
                {
                    response.StatusCode = 404;
                    return "Dot not found";
                }

                var targetComments = db.Comments.Where(c => c.dotId == dotIdValue);
                
                db.Comments.RemoveRange(targetComments);
                db.SaveChanges();
                return "Delete";
            });

        }
    }
}
