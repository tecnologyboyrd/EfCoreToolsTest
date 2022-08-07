// See https://aka.ms/new-console-template for more information
using EfCoreToolsTest;
using EfCoreToolsTest.DbContext;
using EfCoreToolsTest.Models;

Console.WriteLine("Prueba del EF Core Tools");

//using (var Context = new DesignPatternsContext())
//{
//    foreach (var element in Context.REJEMPLO_PU.ToList())
//    {
//        Console.WriteLine($"Usuario : {element.Student} \t User Id : {element.Semester}");
//    }
//}


#region "ejemplo de ultimos 3 registros para Pu"

/*
 * 
 * script de la tablas de DB con todos los registros
 * 
 * 
 CREATE TABLE REJEMPLO_PU
(
	RecordId INT IDENTITY
	,Student VARCHAR(20)
	,Semester INT 
	,Qualification NUMERIC(18,2)
)


INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 1, 70)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 2, 71)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 3, 72)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 4, 73)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 5, 74)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 6, 75)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('JHON PU', 7, 75)

INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('LEONARD PEREZ', 1, 95)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('LEONARD PEREZ', 2, 96)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('LEONARD PEREZ', 3, 97)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('LEONARD PEREZ', 4, 98)
INSERT INTO REJEMPLO_PU (Student,Semester,Qualification) VALUES ('LEONARD PEREZ', 5, 99)


De esta manera se hace el select en SQL

WITH TOP3 AS (
    SELECT *, ROW_NUMBER() 
    over (
        PARTITION BY Student 
        order by Semester DESC
    ) AS RowNo 
    FROM REJEMPLO_PU
)
SELECT * FROM TOP3 WHERE RowNo <= 3

 */


using (var Context = new DesignPatternsContext())
{   

    var ex = Context.REJEMPLO_PU.ToList().GroupBy(row => row.Student)
        .SelectMany(x => x.OrderByDescending(row => row.Semester).Take(3)).ToList();


    foreach (var element in ex)
    {
        Console.WriteLine($"Student : {element.Student} \t Semester : {element.Semester} \t  Qualification : {element.Qualification}");
    }

    Console.ReadLine();

}

#endregion




