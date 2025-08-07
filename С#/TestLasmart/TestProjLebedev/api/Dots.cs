using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.RegularExpressions;
using TestProjLebedev.db;


namespace TestProjLebedev.api
{
    public static class Dots
    {
        public static void addEndpoints(WebApplication app)
        {
            app.MapGet("/api/dots", (DB db, HttpResponse response) => {
                db.Database.EnsureCreated();      
                return JsonSerializer.Serialize(db.Dots.ToList());
            });

            app.MapGet("/api/dots/{id}", (string id, DB db, HttpRequest request, HttpResponse response) => {
                bool correctId = int.TryParse(id, out int idValue);
                if (!(correctId && idValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }
                db.Database.EnsureCreated();

                var dotData = db.Dots.FirstOrDefault(d => d.id == idValue);
                if(dotData == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }

                response.ContentType = "application/json";
                return JsonSerializer.Serialize(dotData);
            });

            app.MapPost("/api/dots", (DB db, HttpRequest request, HttpResponse response) => {
                db.Database.EnsureCreated();
                try{
                    request.Form.ToDictionary();
                }
                catch(System.InvalidOperationException e) {
                    response.StatusCode = 400;
                    return "Incorrect body";
                }
                var paramsDict = request.Form.ToDictionary();
                

                if (
                    !(paramsDict.ContainsKey("x") &&
                    paramsDict.ContainsKey("y") &&
                    paramsDict.ContainsKey("color") &&
                    paramsDict.ContainsKey("radius")
                    )
                )
                {
                    response.StatusCode = 400;
                    return "Incorrect post keys!";
                }

                if (!(int.TryParse(paramsDict["x"], out int x) && x >= 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect x key value!";
                }

                if (!(int.TryParse(paramsDict["y"], out int y) && y >= 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect y key value!";
                }

                if (!Regex.Match(paramsDict["color"], @"^[0-9a-fA-f]{6}$").Success)
                {
                    response.StatusCode = 400;
                    return "Incorrect color key value!";
                }

                if (!(int.TryParse(paramsDict["radius"], out int radius) && radius > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect radius key value!";
                }
               
                Dot dot = new Dot { x = x, y = y, color = paramsDict["color"], radius = radius };
                db.Dots.Add(dot);
                db.SaveChanges();
                return dot.id.ToString();
            });

            app.MapPut("/api/dots/{id:int}", (string id, DB db, HttpRequest request, HttpResponse response) => {
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

                var targetDot = db.Dots.FirstOrDefault(d => d.id == idValue);
                if (targetDot == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }


                if (paramsDict.ContainsKey("x") && !String.IsNullOrEmpty(paramsDict["x"]))
                {
                    if(!(int.TryParse(paramsDict["x"], out int x) && x >= 0))
                    {
                        response.StatusCode = 400;
                        return "Incorrect x key value!";
                    }
                    targetDot.x = x;
                }

                if (paramsDict.ContainsKey("y") && !String.IsNullOrEmpty(paramsDict["y"]))
                {
                    if (!(int.TryParse(paramsDict["y"], out int y) && y >= 0))
                    {
                        response.StatusCode = 400;
                        return "Incorrect y key value!";
                    }
                    targetDot.y = y;
                }

                if (paramsDict.ContainsKey("color") && !String.IsNullOrEmpty(paramsDict["color"]))
                {
                    if (!Regex.Match(paramsDict["color"], @"^[0-9a-fA-f]{6}$").Success)
                    {
                        response.StatusCode = 400;
                        return "Incorrect color key value!";
                    }
                    targetDot.color = paramsDict["color"];
                }

                if (paramsDict.ContainsKey("radius") && !String.IsNullOrEmpty(paramsDict["radius"]))
                {
                    if (!(int.TryParse(paramsDict["radius"], out int radius) && radius >= 0))
                    {
                        response.StatusCode = 400;
                        return "Incorrect radius key value!";
                    }
                    targetDot.radius = radius;
                }

                db.SaveChanges();
                response.ContentType = "application/json";
                return JsonSerializer.Serialize(targetDot);
            });

            app.MapDelete("/api/dots/{id}", (string id, DB db, HttpResponse response) => {
                bool correctId = int.TryParse(id, out int idValue);
                if (!(correctId && idValue > 0))
                {
                    response.StatusCode = 400;
                    return "Incorrect id";
                }

                db.Database.EnsureCreated();

                var targetDot = db.Dots.FirstOrDefault(d => d.id == idValue);
                if (targetDot == null)
                {
                    response.StatusCode = 404;
                    return "Not found";
                }

                var targetComments = db.Comments.Where(d => d.dotId == idValue);
                db.Comments.RemoveRange(targetComments);

                db.Dots.Remove(targetDot);

                db.SaveChanges();
                return "Delete";
            });

        }
    }
}
