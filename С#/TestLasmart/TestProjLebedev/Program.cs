using Microsoft.EntityFrameworkCore;
using TestProjLebedev.db;
using TestProjLebedev.api;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
/* Использется строка соединения с БД из appsettings.json
 * В данном случае используется строка подключения для базы данных "из-памяти", 
 * которая создается динамически при запуске приложения
 */
//builder.WebHost.UseWebRoot("public");

string? connection = builder.Configuration.GetConnectionString("MemoryConnection");
/*
 * Добавление класса "контекста" БД.
 * Исходный файл контекста БД находится в db/DB.cs
 * Реализуемые схемы таблиц для БД находятся db/Tables.cs
 */
builder.Services.AddSingleton<DB>(new DB(connection));
WebApplication app = builder.Build();

/* Открытие соединения с БД глобально */
DB db = app.Services.GetRequiredService<DB>();
db.Database.OpenConnection();

/*Добавление эндпоинтов api для взаимодействия с БД*/
// Подключение api эндпоинтов для взаимодействия с таблицей Dots на ветке /api/dots
Dots.addEndpoints(app);
// Подключение api эндпоинтов для взаимодействия с таблицей Comments на ветке /api/comments
Comments.addEndpoints(app);

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

/*
 * Претензии к собственной работе
 * 
 * 1) Между таблицами не установлена связь по ключам id=>dotId т.к. установка ключей
 * вызывает рекурсиивную ссылочность при формировании json ответов через JsonSerializer.
 * По хорошему надо найти способ обеспечения каскадного удаления данных на уровне базы,
 * но тогда при необходимо всегда увеличивать код для процесса сериализации через JsonSerializer.
 * Для ускорения времени выполнения ТЗ был сделан выбор в пользу обеспечения каскадности программно
 * через выполнение доп запросов для очистки зависимых сущностей.
 * 
 * 2) В файле api/Comments.cs есть добавление ветки /api/dots/{dotId}/comments.
 * так как реализуется взаимодействие с таблицей comments я решил поместить эту ветку в этот.
 * в качестве альтернативы можно было бы добавить ветку вида /api/comments/dotid/{dotId},
 * но мне показалась эта ветка менее интуитивной.
 * 
 */