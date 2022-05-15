using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Dapper;
using Microsoft.Data.Sqlite;


namespace UnitTests
{
    public class GATests
    {
        [Fact]
        public void GATest()
        {
            using var d = new Database();

            var dbString = new Dapper.DbString();
            dbString.Value = "Data Source=lines.db";

            using var con = new SqliteConnection(dbString.Value);
            var points = con.QueryAsync<Point>("SELECT * from points").Result;

            var linesSql = @"SELECT *
                            from lines
                            left join Points as StartPoints on StartPoints.Id = StartPointId
                            left join Points as EndPoints on EndPoints.Id = EndPointId
                            LIMIT 50";
            var lines = con.QueryAsync<Line, Point, Point, Line>(linesSql, ((line, stPoint, endPoint) =>
            {
                line.StartPoint = stPoint;
                line.EndPoint = endPoint;
                return line;
            })).Result;
           

            var ga = new SnowPlowSolver.GA(500, 200, 0.2);

            var starting = ga.FitnessFunction.CalculateScore(lines);
            var opPath = ga.OptimizePath(lines);


            starting.Should().BeGreaterThan(ga.FitnessFunction.CalculateScore(opPath));
        }
    }
}
