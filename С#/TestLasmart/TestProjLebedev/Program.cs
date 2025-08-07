using Microsoft.EntityFrameworkCore;
using TestProjLebedev.db;
using TestProjLebedev.api;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
/* ����������� ������ ���������� � �� �� appsettings.json
 * � ������ ������ ������������ ������ ����������� ��� ���� ������ "��-������", 
 * ������� ��������� ����������� ��� ������� ����������
 */
//builder.WebHost.UseWebRoot("public");

string? connection = builder.Configuration.GetConnectionString("MemoryConnection");
/*
 * ���������� ������ "���������" ��.
 * �������� ���� ��������� �� ��������� � db/DB.cs
 * ����������� ����� ������ ��� �� ��������� db/Tables.cs
 */
builder.Services.AddSingleton<DB>(new DB(connection));
WebApplication app = builder.Build();

/* �������� ���������� � �� ��������� */
DB db = app.Services.GetRequiredService<DB>();
db.Database.OpenConnection();

/*���������� ���������� api ��� �������������� � ��*/
// ����������� api ���������� ��� �������������� � �������� Dots �� ����� /api/dots
Dots.addEndpoints(app);
// ����������� api ���������� ��� �������������� � �������� Comments �� ����� /api/comments
Comments.addEndpoints(app);

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

/*
 * ��������� � ����������� ������
 * 
 * 1) ����� ��������� �� ����������� ����� �� ������ id=>dotId �.�. ��������� ������
 * �������� ������������ ����������� ��� ������������ json ������� ����� JsonSerializer.
 * �� �������� ���� ����� ������ ����������� ���������� �������� ������ �� ������ ����,
 * �� ����� ��� ���������� ������ ����������� ��� ��� �������� ������������ ����� JsonSerializer.
 * ��� ��������� ������� ���������� �� ��� ������ ����� � ������ ����������� ����������� ����������
 * ����� ���������� ��� �������� ��� ������� ��������� ���������.
 * 
 * 2) � ����� api/Comments.cs ���� ���������� ����� /api/dots/{dotId}/comments.
 * ��� ��� ����������� �������������� � �������� comments � ����� ��������� ��� ����� � ����.
 * � �������� ������������ ����� ���� �� �������� ����� ���� /api/comments/dotid/{dotId},
 * �� ��� ���������� ��� ����� ����� �����������.
 * 
 */