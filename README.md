Just change the conections string.

And 

Run this query in SQL Server


CREATE DATABASE DailyRoutineAlert
USE DailyRoutineAlert
CREATE TABLE RoutineDetail
(
    RoutineId INT IDENTITY PRIMARY KEY,
    RoutineTitle VARCHAR(100),
    RotineScheduledFor DATETIME
)

