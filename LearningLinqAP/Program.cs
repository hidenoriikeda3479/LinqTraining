using LearningLinqAP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;

namespace LearningLinqAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // テストデータの生成
            var employees = CreateTestEmployees();
            var departments = CreateTestDepartments();

            // 課題の実行
            // ※指定された部分以外はコードを触らないこと
            SelectBasic(employees);
            WhereBasic(employees);
            SelectWhereBasic(employees, departments);

            SelectAdvanced(employees);
            WhereAdvanced(employees);

            SelectDifficult(employees);
            WhereDifficult(employees);
            SelectWhereDifficult(employees);

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        /// <summary>
        /// selectの課題: 全社員の名前を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void SelectBasic(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Select(n => n.Name);

            #region Expected
            var expected = new List<string> { "田中", "鈴木", "佐藤", "山田", "加藤" };
            PrintResult("全社員の名前を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// Whereの課題: 給与が60000以上の社員を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void WhereBasic(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Where(n => n.Salary >= 60000).Select(n => n.Name);

            //var result = employees.Where(n => n.Salary >= 60000).Select(n => n.Name);

            #region Expected
            var expected = new List<string> { "鈴木", "山田" };
            PrintResult("給与が60000以上の社員を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// selectとWhereの組み合わせの課題: 部門が"IT"である社員の名前を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        /// <param name="departments">部門リスト</param>
        static void SelectWhereBasic(List<Employee> employees, List<Department> departments)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Where(n => n.DepartmentId == 1).Select(n => n.Name);

            #region Expected
            var expected = new List<string> { "田中", "山田" };
            PrintResult("部門が\"IT\"である社員の名前を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// selectの課題: 全社員の入社日を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void SelectAdvanced(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Select(n => n.JoinDate);

            #region Expected
            var expected = new List<DateTime>
            {
                new DateTime(2018, 1, 1),
                new DateTime(2017, 1, 1),
                new DateTime(2018, 5, 1),
                new DateTime(2016, 1, 1),
                new DateTime(2015, 1, 1)
            };
            PrintResult("全社員の入社日を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// Whereの課題: 部門IDが2の社員を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void WhereAdvanced(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Where(n => n.DepartmentId == 2).Select(n => n.Name);

            #region Expected
            var expected = new List<string> { "鈴木", "佐藤" };
            PrintResult("部門IDが2の社員を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// selectの課題: 全社員の部門IDを取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void SelectDifficult(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Select(n => n.DepartmentId);

            #region Expected
            var expected = new List<int> { 1, 2, 2, 1, 3 };
            PrintResult("全社員の部門IDを取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// Whereの課題: 入社日が2018年以降の社員を取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void WhereDifficult(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            //日付比較のため、新たにデータタイムの変数を宣言
            var a = new DateTime(2018 , 1 , 1);
            var result = employees.Where(n => n.JoinDate >= a).Select(n => n.Name);

            #region Expected
            var expected = new List<string> { "田中", "佐藤" };
            PrintResult("入社日が2018年以降の社員を取得する課題", result.SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// selectとWhereの組み合わせの課題: 部門IDが1で、給与が55000以上の社員の名前と部門IDを取得
        /// </summary>
        /// <param name="employees">社員リスト</param>
        static void SelectWhereDifficult(List<Employee> employees)
        {
            // resultに抽出結果を入れてね。
            var result = employees.Where(n => n.DepartmentId == 1 && n.Salary > 55000).ToArray();

            #region Expected
            var expected = new List<(string Name, int DepartmentId)>
            {
                ("山田", 1)
            };
            PrintResult("部門IDが1で、給与が55000以上の社員の名前と部門IDを取得する課題", result
                .Select(e => (e.Name, e.DepartmentId))
                .SequenceEqual(expected));
            #endregion
        }

        /// <summary>
        /// 社員データ作成
        /// </summary>
        /// <returns></returns>
        static List<Employee> CreateTestEmployees()
        {
            return new List<Employee>
            {
                new Employee { EmployeeId = 1, Name = "田中", DepartmentId = 1, JoinDate = new DateTime(2018, 1, 1), Salary = 50000 },
                new Employee { EmployeeId = 2, Name = "鈴木", DepartmentId = 2, JoinDate = new DateTime(2017, 1, 1), Salary = 70000 },
                new Employee { EmployeeId = 3, Name = "佐藤", DepartmentId = 2, JoinDate = new DateTime(2018, 5, 1), Salary = 45000 },
                new Employee { EmployeeId = 4, Name = "山田", DepartmentId = 1, JoinDate = new DateTime(2016, 1, 1), Salary = 60000 },
                new Employee { EmployeeId = 5, Name = "加藤", DepartmentId = 3, JoinDate = new DateTime(2015, 1, 1), Salary = 40000 }
            };
        }

        /// <summary>
        /// 部門データ作成
        /// </summary>
        /// <returns></returns>
        static List<Department> CreateTestDepartments()
        {
            return new List<Department>
            {
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "営業" },
                new Department { DepartmentId = 3, DepartmentName = "総務" }
            };
        }

        #region 結果を色付きで表示するメソッド
        /// <summary>
        /// 結果を色付きで表示するメソッド
        /// </summary>
        /// <param name="taskName">課題名</param>
        /// <param name="isCorrect">結果が正しいかどうか</param>
        static void PrintResult(string taskName, bool isCorrect)
        {
            var originalColor = Console.ForegroundColor;
            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{taskName}: 正解");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{taskName}: 不正解");
                SystemSounds.Hand.Play();
            }
            Console.ForegroundColor = originalColor;
        }
        #endregion
    }
}
