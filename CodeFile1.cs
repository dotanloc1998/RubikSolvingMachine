using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RubikCube
{
    public class Rubik
    {
        private string[,] u = new string[3, 3];
        private string[,] f = new string[3, 3];
        private string[,] l = new string[3, 3];
        private string[,] r = new string[3, 3];
        private string[,] b = new string[3, 3];
        private string[,] d = new string[3, 3];
        private List<string> result = new List<string>();
        private List<string> result1 = new List<string>();
        public Rubik()
        {
            int mark = 1;
            for (int i = 0; i < u.GetLength(0); i++)
            {
                for (int j = 0; j < u.GetLength(1); j++)
                {
                    u[i, j] = "w" + Convert.ToString(mark);
                    f[i, j] = "g" + Convert.ToString(mark);
                    l[i, j] = "o" + Convert.ToString(mark);
                    r[i, j] = "r" + Convert.ToString(mark);
                    b[i, j] = "b" + Convert.ToString(mark);
                    d[i, j] = "y" + Convert.ToString(mark);
                    mark++;
                }
            }
        }
        public void Print(string output)
        {
            StreamWriter sw = new StreamWriter(output);
            /*Print U side*/
            for (int i = 0; i < u.GetLength(0); i++)
            {
                sw.Write("       ");
                for (int j = 0; j < u.GetLength(1); j++)
                {
                    sw.Write(u[i, j][0] + " ");
                }
                sw.WriteLine();
            }
            sw.WriteLine();
            /*Print L - F - R - B*/
            sw.WriteLine("{0} {1} {2}  {3} {4} {5}  {6} {7} {8}  {9} {10} {11}", l[0, 0][0], l[0, 1][0], l[0, 2][0], f[0, 0][0], f[0, 1][0], f[0, 2][0], r[0, 0][0], r[0, 1][0], r[0, 2][0], b[0, 0][0], b[0, 1][0], b[0, 2][0]);
            sw.WriteLine("{0} {1} {2}  {3} {4} {5}  {6} {7} {8}  {9} {10} {11}", l[1, 0][0], l[1, 1][0], l[1, 2][0], f[1, 0][0], f[1, 1][0], f[1, 2][0], r[1, 0][0], r[1, 1][0], r[1, 2][0], b[1, 0][0], b[1, 1][0], b[1, 2][0]);
            sw.WriteLine("{0} {1} {2}  {3} {4} {5}  {6} {7} {8}  {9} {10} {11}", l[2, 0][0], l[2, 1][0], l[2, 2][0], f[2, 0][0], f[2, 1][0], f[2, 2][0], r[2, 0][0], r[2, 1][0], r[2, 2][0], b[2, 0][0], b[2, 1][0], b[2, 2][0]);
            sw.WriteLine();

            /*Print D side*/
            for (int i = 0; i < d.GetLength(0); i++)
            {
                sw.Write("       ");
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    sw.Write(d[i, j][0] + " ");
                }
                sw.WriteLine();
            }
            sw.WriteLine();
            sw.WriteLine("Special thanks to Hưng Trịnh and Trường Phan");
            sw.Close();
        }
        private void AssignListBToA(List<string> a, List<string> b)
        {
            a.Clear();
            foreach (string variable in b)
            {
                a.Add(variable);
            }
        }
        private void PrintFomula()
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i][0] == 'U')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "U" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3] == "U")
                        {
                            i += 3;
                        }
                        else if (result[i] == "U" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3][0] != 'U')
                        {
                            result1.Add("U'");
                            i += 2;
                        }
                        else if (result[i] == "U" && result[i + 1] == "U" && result[i + 2][0] != 'U')
                        {
                            result1.Add("U2");
                            i++;
                        }
                        else if (result[i] == "U" && result[i + 1][0] != 'U')
                        {
                            result1.Add("U");
                        }
                        else if (result[i] == "U2" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3] == "U")
                        {
                            result1.Add("U");
                            i += 3;
                        }
                        else if (result[i] == "U2" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3][0] != 'U')
                        {
                            i += 2;
                        }
                        else if (result[i] == "U2" && result[i + 1] == "U" && result[i + 2][0] != 'U')
                        {
                            result1.Add("U'");
                            i++;
                        }
                        else if (result[i] == "U2" && result[i + 1][0] != 'U')
                        {
                            result1.Add("U2");
                        }
                        else if (result[i] == "U'" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3] == "U")
                        {
                            result1.Add("U2");
                            i += 3;
                        }
                        else if (result[i] == "U'" && result[i + 1] == "U" && result[i + 2] == "U" && result[i + 3][0] != 'U')
                        {
                            result1.Add("U");
                            i += 2;
                        }
                        else if (result[i] == "U'" && result[i + 1] == "U" && result[i + 2][0] != 'U')
                        {

                            i++;
                        }
                        else if (result[i] == "U'" && result[i + 1][0] != 'U')
                        {
                            result1.Add("U'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else if (result[i][0] == 'L')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "L" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3] == "L")
                        {
                            i += 3;
                        }
                        else if (result[i] == "L" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3][0] != 'L')
                        {
                            result1.Add("L'");
                            i += 2;
                        }
                        else if (result[i] == "L" && result[i + 1] == "L" && result[i + 2][0] != 'L')
                        {
                            result1.Add("L2");
                            i++;
                        }
                        else if (result[i] == "L" && result[i + 1][0] != 'L')
                        {
                            result1.Add("L");
                        }
                        else if (result[i] == "L2" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3] == "L")
                        {
                            result1.Add("L");
                            i += 3;
                        }
                        else if (result[i] == "L2" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3][0] != 'L')
                        {
                            i += 2;
                        }
                        else if (result[i] == "L2" && result[i + 1] == "L" && result[i + 2][0] != 'L')
                        {
                            result1.Add("L'");
                            i++;
                        }
                        else if (result[i] == "L2" && result[i + 1][0] != 'L')
                        {
                            result1.Add("L2");
                        }
                        else if (result[i] == "L'" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3] == "L")
                        {
                            result1.Add("L2");
                            i += 3;
                        }
                        else if (result[i] == "L'" && result[i + 1] == "L" && result[i + 2] == "L" && result[i + 3][0] != 'L')
                        {
                            result1.Add("L");
                            i += 2;
                        }
                        else if (result[i] == "L'" && result[i + 1] == "L" && result[i + 2][0] != 'L')
                        {

                            i++;
                        }
                        else if (result[i] == "L'" && result[i + 1][0] != 'L')
                        {
                            result1.Add("L'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else if (result[i][0] == 'R')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "R" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3] == "R")
                        {
                            i += 3;
                        }
                        else if (result[i] == "R" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3][0] != 'R')
                        {
                            result1.Add("R'");
                            i += 2;
                        }
                        else if (result[i] == "R" && result[i + 1] == "R" && result[i + 2][0] != 'R')
                        {
                            result1.Add("R2");
                            i++;
                        }
                        else if (result[i] == "R" && result[i + 1][0] != 'R')
                        {
                            result1.Add("R");
                        }
                        else if (result[i] == "R2" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3] == "R")
                        {
                            result1.Add("R");
                            i += 3;
                        }
                        else if (result[i] == "R2" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3][0] != 'R')
                        {
                            i += 2;
                        }
                        else if (result[i] == "R2" && result[i + 1] == "R" && result[i + 2][0] != 'R')
                        {
                            result1.Add("R'");
                            i++;
                        }
                        else if (result[i] == "R2" && result[i + 1][0] != 'R')
                        {
                            result1.Add("R2");
                        }
                        else if (result[i] == "R'" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3] == "R")
                        {
                            result1.Add("R2");
                            i += 3;
                        }
                        else if (result[i] == "R'" && result[i + 1] == "R" && result[i + 2] == "R" && result[i + 3][0] != 'R')
                        {
                            result1.Add("R");
                            i += 2;
                        }
                        else if (result[i] == "R'" && result[i + 1] == "R" && result[i + 2][0] != 'R')
                        {
                            i++;
                        }
                        else if (result[i] == "R'" && result[i + 1][0] != 'R')
                        {
                            result1.Add("R'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else if (result[i][0] == 'D')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "D" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3] == "D")
                        {
                            i += 3;
                        }
                        else if (result[i] == "D" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3][0] != 'D')
                        {
                            result1.Add("D'");
                            i += 2;
                        }
                        else if (result[i] == "D" && result[i + 1] == "D" && result[i + 2][0] != 'D')
                        {
                            result1.Add("D2");
                            i++;
                        }
                        else if (result[i] == "D" && result[i + 1][0] != 'D')
                        {
                            result1.Add("D");
                        }
                        else if (result[i] == "D2" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3] == "D")
                        {
                            result1.Add("D");
                            i += 3;
                        }
                        else if (result[i] == "D2" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3][0] != 'D')
                        {
                            i += 2;
                        }
                        else if (result[i] == "D2" && result[i + 1] == "D" && result[i + 2][0] != 'D')
                        {
                            result1.Add("D'");
                            i++;
                        }
                        else if (result[i] == "D2" && result[i + 1][0] != 'D')
                        {
                            result1.Add("D2");
                        }
                        else if (result[i] == "D'" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3] == "D")
                        {
                            result1.Add("D2");
                            i += 3;
                        }
                        else if (result[i] == "D'" && result[i + 1] == "D" && result[i + 2] == "D" && result[i + 3][0] != 'D')
                        {
                            result1.Add("D");
                            i += 2;
                        }
                        else if (result[i] == "D'" && result[i + 1] == "D" && result[i + 2][0] != 'D')
                        {
                            i++;
                        }
                        else if (result[i] == "D'" && result[i + 1][0] != 'D')
                        {
                            result1.Add("D'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else if (result[i][0] == 'F')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "F" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3] == "F")
                        {
                            i += 3;
                        }
                        else if (result[i] == "F" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3][0] != 'F')
                        {
                            result1.Add("F'");
                            i += 2;
                        }
                        else if (result[i] == "F" && result[i + 1] == "F" && result[i + 2][0] != 'F')
                        {
                            result1.Add("F2");
                            i++;
                        }
                        else if (result[i] == "F" && result[i + 1][0] != 'F')
                        {
                            result1.Add("F");
                        }
                        else if (result[i] == "F2" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3] == "F")
                        {
                            result1.Add("F");
                            i += 3;
                        }
                        else if (result[i] == "F2" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3][0] != 'F')
                        {
                            i += 2;
                        }
                        else if (result[i] == "F2" && result[i + 1] == "F" && result[i + 2][0] != 'F')
                        {
                            result1.Add("F'");
                            i++;
                        }
                        else if (result[i] == "F2" && result[i + 1][0] != 'F')
                        {
                            result1.Add("F2");
                        }
                        else if (result[i] == "F'" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3] == "F")
                        {
                            result1.Add("F2");
                            i += 3;
                        }
                        else if (result[i] == "F'" && result[i + 1] == "F" && result[i + 2] == "F" && result[i + 3][0] != 'F')
                        {
                            result1.Add("F");
                            i += 2;
                        }
                        else if (result[i] == "F'" && result[i + 1] == "F" && result[i + 2][0] != 'F')
                        {
                            i++;
                        }
                        else if (result[i] == "F'" && result[i + 1][0] != 'F')
                        {
                            result1.Add("F'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else if (result[i][0] == 'B')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "B" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3] == "B")
                        {
                            i += 3;
                        }
                        else if (result[i] == "B" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3][0] != 'B')
                        {
                            result1.Add("B'");
                            i += 2;
                        }
                        else if (result[i] == "B" && result[i + 1] == "B" && result[i + 2][0] != 'B')
                        {
                            result1.Add("B2");
                            i++;
                        }
                        else if (result[i] == "B" && result[i + 1][0] != 'B')
                        {
                            result1.Add("B");
                        }
                        else if (result[i] == "B2" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3] == "B")
                        {
                            result1.Add("B");
                            i += 3;
                        }
                        else if (result[i] == "B2" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3][0] != 'B')
                        {
                            i += 2;
                        }
                        else if (result[i] == "B2" && result[i + 1] == "B" && result[i + 2][0] != 'B')
                        {
                            result1.Add("B'");
                            i++;
                        }
                        else if (result[i] == "B2" && result[i + 1][0] != 'B')
                        {
                            result1.Add("B2");
                        }
                        else if (result[i] == "B'" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3] == "B")
                        {
                            result1.Add("B2");
                            i += 3;
                        }
                        else if (result[i] == "B'" && result[i + 1] == "B" && result[i + 2] == "B" && result[i + 3][0] != 'B')
                        {
                            result1.Add("B");
                            i += 2;
                        }
                        else if (result[i] == "B'" && result[i + 1] == "B" && result[i + 2][0] != 'B')
                        {
                            i++;
                        }
                        else if (result[i] == "B'" && result[i + 1][0] != 'B')
                        {
                            result1.Add("B'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[0]);
                    }
                }
                else if (result[i][0] == 'M')
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "M" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3] == "M")
                        {
                            i += 3;
                        }
                        else if (result[i] == "M" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3][0] != 'M')
                        {
                            result1.Add("M'");
                            i += 2;
                        }
                        else if (result[i] == "M" && result[i + 1] == "M" && result[i + 2][0] != 'M')
                        {
                            result1.Add("M2");
                            i++;
                        }
                        else if (result[i] == "M" && result[i + 1][0] != 'M')
                        {
                            result1.Add("M");
                        }
                        else if (result[i] == "M2" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3] == "M")
                        {
                            result1.Add("M");
                            i += 3;
                        }
                        else if (result[i] == "M2" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3][0] != 'M')
                        {
                            i += 2;
                        }
                        else if (result[i] == "M2" && result[i + 1] == "M" && result[i + 2][0] != 'M')
                        {
                            result1.Add("M'");
                            i++;
                        }
                        else if (result[i] == "M2" && result[i + 1][0] != 'M')
                        {
                            result1.Add("M2");
                        }
                        else if (result[i] == "M'" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3] == "M")
                        {
                            result1.Add("M2");
                            i += 3;
                        }
                        else if (result[i] == "M'" && result[i + 1] == "M" && result[i + 2] == "M" && result[i + 3][0] != 'M')
                        {
                            result1.Add("M");
                            i += 2;
                        }
                        else if (result[i] == "M'" && result[i + 1] == "M" && result[i + 2][0] != 'M')
                        {
                            i++;
                        }
                        else if (result[i] == "M'" && result[i + 1][0] != 'M')
                        {
                            result1.Add("M'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
                else
                {
                    if (i <= result.Count - 3)
                    {
                        if (result[i] == "S" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3] == "S")
                        {
                            i += 3;
                        }
                        else if (result[i] == "S" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3][0] != 'S')
                        {
                            result1.Add("S'");
                            i += 2;
                        }
                        else if (result[i] == "S" && result[i + 1] == "S" && result[i + 2][0] != 'S')
                        {
                            result1.Add("S2");
                            i++;
                        }
                        else if (result[i] == "S" && result[i + 1][0] != 'S')
                        {
                            result1.Add("S");
                        }
                        else if (result[i] == "S2" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3] == "S")
                        {
                            result1.Add("S");
                            i += 3;
                        }
                        else if (result[i] == "S2" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3][0] != 'S')
                        {
                            i += 2;
                        }
                        else if (result[i] == "S2" && result[i + 1] == "S" && result[i + 2][0] != 'S')
                        {
                            result1.Add("S'");
                            i++;
                        }
                        else if (result[i] == "S2" && result[i + 1][0] != 'S')
                        {
                            result1.Add("S2");
                        }
                        else if (result[i] == "S'" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3] == "S")
                        {
                            result1.Add("S2");
                            i += 3;
                        }
                        else if (result[i] == "S'" && result[i + 1] == "S" && result[i + 2] == "S" && result[i + 3][0] != 'S')
                        {
                            result1.Add("S");
                            i += 2;
                        }
                        else if (result[i] == "S'" && result[i + 1] == "S" && result[i + 2][0] != 'S')
                        {
                            i++;
                        }
                        else if (result[i] == "S'" && result[i + 1][0] != 'S')
                        {
                            result1.Add("S'");
                        }
                        else
                        {
                            result1.Add(result[i]);
                        }
                    }
                    else
                    {
                        result1.Add(result[i]);
                    }
                }
            }
        }
        public void PrintAlgorithm(string output)
        {
            StreamWriter sw = new StreamWriter(output);
            for (int i = 0; i < 3; i++)
            {
                PrintFomula();
                AssignListBToA(result,result1);
                result1.Clear();
            }

            foreach (var variable in result)
            {
                sw.Write("{0} ", variable);
            }
            sw.Close();
        }
        public void Read(string input)
        {
            StreamReader sr = new StreamReader(input);
            string[] scramble = sr.ReadLine().Trim().Split(' ');
            for (int i = 0; i < scramble.Length; i++)
            {
                switch (scramble[i][0])
                {
                    case 'U':
                        {
                            if (scramble[i].Length == 2)
                            {
                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        U();
                                    }
                                }
                                else
                                {
                                    ReverseU();
                                }
                            }
                            else
                            {
                                U();
                            }
                        }
                        break;
                    case 'L':
                        {
                            if (scramble[i].Length == 2)
                            {
                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        L();
                                    }
                                }
                                else
                                {
                                    ReverseL();
                                }
                            }
                            else
                            {
                                L();
                            }
                        }
                        break;
                    case 'R':
                        {
                            if (scramble[i].Length == 2)
                            {

                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        R();
                                    }
                                }
                                else
                                {
                                    ReverseR();
                                }
                            }
                            else
                            {
                                R();
                            }
                        }
                        break;
                    case 'F':
                        {
                            if (scramble[i].Length == 2)
                            {
                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        F();
                                    }
                                }
                                else
                                {
                                    ReverseF();
                                }
                            }
                            else
                            {
                                F();
                            }
                        }
                        break;
                    case 'B':
                        {
                            if (scramble[i].Length == 2)
                            {

                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        B();
                                    }
                                }
                                else
                                {
                                    ReverseB();
                                }
                            }
                            else
                            {
                                B();
                            }
                        }
                        break;
                    case 'D':
                        {
                            if (scramble[i].Length == 2)
                            {
                                if (scramble[i][1] != '\'')
                                {
                                    for (int j = 0; j < int.Parse(Convert.ToString(scramble[i][1])); j++)
                                    {
                                        D();
                                    }
                                }
                                else
                                {
                                    ReverseD();
                                }
                            }
                            else
                            {
                                D();
                            }
                        }
                        break;
                }
            }
            result = new List<string>();
            sr.Close();
        }
        private void AssignBToA(string[,] a, string[,] b)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = b[i, j];
                }
            }
        }
        private void U()
        {
            /*Changes sides aroud U*/
            result.Add("U");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, u);
            temp[0] = b[0, 0];
            temp[1] = b[0, 1];
            temp[2] = b[0, 2];

            b[0, 0] = l[0, 0];
            b[0, 1] = l[0, 1];
            b[0, 2] = l[0, 2];

            l[0, 0] = f[0, 0];
            l[0, 1] = f[0, 1];
            l[0, 2] = f[0, 2];

            f[0, 0] = r[0, 0];
            f[0, 1] = r[0, 1];
            f[0, 2] = r[0, 2];

            r[0, 0] = temp[0];
            r[0, 1] = temp[1];
            r[0, 2] = temp[2];

            /*Changes U face*/
            u[0, 0] = temp2[2, 0];
            u[0, 1] = temp2[1, 0];
            u[0, 2] = temp2[0, 0];

            u[1, 0] = temp2[2, 1];
            u[1, 1] = temp2[1, 1];
            u[1, 2] = temp2[0, 1];

            u[2, 0] = temp2[2, 2];
            u[2, 1] = temp2[1, 2];
            u[2, 2] = temp2[0, 2];
        }
        private void ReverseU()
        {
            result.Add("U'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, u);
            temp[0] = b[0, 0];
            temp[1] = b[0, 1];
            temp[2] = b[0, 2];

            b[0, 0] = r[0, 0];
            b[0, 1] = r[0, 1];
            b[0, 2] = r[0, 2];

            r[0, 0] = f[0, 0];
            r[0, 1] = f[0, 1];
            r[0, 2] = f[0, 2];

            f[0, 0] = l[0, 0];
            f[0, 1] = l[0, 1];
            f[0, 2] = l[0, 2];

            l[0, 0] = temp[0];
            l[0, 1] = temp[1];
            l[0, 2] = temp[2];


            u[0, 0] = temp2[0, 2];
            u[0, 1] = temp2[1, 2];
            u[0, 2] = temp2[2, 2];

            u[1, 0] = temp2[0, 1];
            u[1, 1] = temp2[1, 1];
            u[1, 2] = temp2[2, 1];

            u[2, 0] = temp2[0, 0];
            u[2, 1] = temp2[1, 0];
            u[2, 2] = temp2[2, 0];
        }
        private void L()
        {
            result.Add("L");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, l);
            temp[0] = u[0, 0];
            temp[1] = u[1, 0];
            temp[2] = u[2, 0];

            u[0, 0] = b[2, 2];
            u[1, 0] = b[1, 2];
            u[2, 0] = b[0, 2];

            b[2, 2] = d[0, 0];
            b[1, 2] = d[1, 0];
            b[0, 2] = d[2, 0];

            d[0, 0] = f[0, 0];
            d[1, 0] = f[1, 0];
            d[2, 0] = f[2, 0];

            f[0, 0] = temp[0];
            f[1, 0] = temp[1];
            f[2, 0] = temp[2];


            l[0, 0] = temp2[2, 0];
            l[0, 1] = temp2[1, 0];
            l[0, 2] = temp2[0, 0];
            l[1, 0] = temp2[2, 1];
            l[1, 1] = temp2[1, 1];
            l[1, 2] = temp2[0, 1];
            l[2, 0] = temp2[2, 2];
            l[2, 1] = temp2[1, 2];
            l[2, 2] = temp2[0, 2];

        }
        private void ReverseL()
        {
            result.Add("L'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, l);
            temp[0] = u[0, 0];
            temp[1] = u[1, 0];
            temp[2] = u[2, 0];

            u[0, 0] = f[0, 0];
            u[1, 0] = f[1, 0];
            u[2, 0] = f[2, 0];

            f[0, 0] = d[0, 0];
            f[1, 0] = d[1, 0];
            f[2, 0] = d[2, 0];

            d[0, 0] = b[2, 2];
            d[1, 0] = b[1, 2];
            d[2, 0] = b[0, 2];

            b[0, 2] = temp[2];
            b[1, 2] = temp[1];
            b[2, 2] = temp[0];


            l[0, 0] = temp2[0, 2];
            l[0, 1] = temp2[1, 2];
            l[0, 2] = temp2[2, 2];
            l[1, 0] = temp2[0, 1];
            l[1, 1] = temp2[1, 1];
            l[1, 2] = temp2[2, 1];
            l[2, 0] = temp2[0, 0];
            l[2, 1] = temp2[1, 0];
            l[2, 2] = temp2[2, 0];
        }
        private void R()
        {
            result.Add("R");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, r);
            temp[0] = u[0, 2];
            temp[1] = u[1, 2];
            temp[2] = u[2, 2];

            u[0, 2] = f[0, 2];
            u[1, 2] = f[1, 2];
            u[2, 2] = f[2, 2];

            f[0, 2] = d[0, 2];
            f[1, 2] = d[1, 2];
            f[2, 2] = d[2, 2];

            d[0, 2] = b[2, 0];
            d[1, 2] = b[1, 0];
            d[2, 2] = b[0, 0];

            b[2, 0] = temp[0];
            b[1, 0] = temp[1];
            b[0, 0] = temp[2];


            r[0, 0] = temp2[2, 0];
            r[0, 1] = temp2[1, 0];
            r[0, 2] = temp2[0, 0];
            r[1, 0] = temp2[2, 1];
            r[1, 1] = temp2[1, 1];
            r[1, 2] = temp2[0, 1];
            r[2, 0] = temp2[2, 2];
            r[2, 1] = temp2[1, 2];
            r[2, 2] = temp2[0, 2];
        }
        private void ReverseR()
        {
            result.Add("R'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, r);
            temp[0] = u[0, 2];
            temp[1] = u[1, 2];
            temp[2] = u[2, 2];

            u[0, 2] = b[2, 0];
            u[1, 2] = b[1, 0];
            u[2, 2] = b[0, 0];

            b[2, 0] = d[0, 2];
            b[1, 0] = d[1, 2];
            b[0, 0] = d[2, 2];

            d[0, 2] = f[0, 2];
            d[1, 2] = f[1, 2];
            d[2, 2] = f[2, 2];

            f[0, 2] = temp[0];
            f[1, 2] = temp[1];
            f[2, 2] = temp[2];


            r[0, 0] = temp2[0, 2];
            r[0, 1] = temp2[1, 2];
            r[0, 2] = temp2[2, 2];
            r[1, 0] = temp2[0, 1];
            r[1, 1] = temp2[1, 1];
            r[1, 2] = temp2[2, 1];
            r[2, 0] = temp2[0, 0];
            r[2, 1] = temp2[1, 0];
            r[2, 2] = temp2[2, 0];
        }
        private void D()
        {
            result.Add("D");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, d);
            temp[0] = f[2, 0];
            temp[1] = f[2, 1];
            temp[2] = f[2, 2];

            f[2, 0] = l[2, 0];
            f[2, 1] = l[2, 1];
            f[2, 2] = l[2, 2];

            l[2, 0] = b[2, 0];
            l[2, 1] = b[2, 1];
            l[2, 2] = b[2, 2];

            b[2, 0] = r[2, 0];
            b[2, 1] = r[2, 1];
            b[2, 2] = r[2, 2];

            r[2, 0] = temp[0];
            r[2, 1] = temp[1];
            r[2, 2] = temp[2];


            d[0, 0] = temp2[2, 0];
            d[0, 1] = temp2[1, 0];
            d[0, 2] = temp2[0, 0];
            d[1, 0] = temp2[2, 1];
            d[1, 1] = temp2[1, 1];
            d[1, 2] = temp2[0, 1];
            d[2, 0] = temp2[2, 2];
            d[2, 1] = temp2[1, 2];
            d[2, 2] = temp2[0, 2];
        }
        private void ReverseD()
        {
            result.Add("D'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, d);
            temp[0] = f[2, 0];
            temp[1] = f[2, 1];
            temp[2] = f[2, 2];

            f[2, 0] = r[2, 0];
            f[2, 1] = r[2, 1];
            f[2, 2] = r[2, 2];

            r[2, 0] = b[2, 0];
            r[2, 1] = b[2, 1];
            r[2, 2] = b[2, 2];

            b[2, 0] = l[2, 0];
            b[2, 1] = l[2, 1];
            b[2, 2] = l[2, 2];

            l[2, 0] = temp[0];
            l[2, 1] = temp[1];
            l[2, 2] = temp[2];


            d[0, 0] = temp2[0, 2];
            d[0, 1] = temp2[1, 2];
            d[0, 2] = temp2[2, 2];
            d[1, 0] = temp2[0, 1];
            d[1, 1] = temp2[1, 1];
            d[1, 2] = temp2[2, 1];
            d[2, 0] = temp2[0, 0];
            d[2, 1] = temp2[1, 0];
            d[2, 2] = temp2[2, 0];
        }
        private void F()
        {
            result.Add("F");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, f);
            temp[0] = u[2, 0];
            temp[1] = u[2, 1];
            temp[2] = u[2, 2];

            u[2, 0] = l[2, 2];
            u[2, 1] = l[1, 2];
            u[2, 2] = l[0, 2];

            l[2, 2] = d[0, 2];
            l[1, 2] = d[0, 1];
            l[0, 2] = d[0, 0];

            d[0, 2] = r[0, 0];
            d[0, 1] = r[1, 0];
            d[0, 0] = r[2, 0];

            r[0, 0] = temp[0];
            r[1, 0] = temp[1];
            r[2, 0] = temp[2];


            f[0, 0] = temp2[2, 0];
            f[0, 1] = temp2[1, 0];
            f[0, 2] = temp2[0, 0];
            f[1, 0] = temp2[2, 1];
            f[1, 1] = temp2[1, 1];
            f[1, 2] = temp2[0, 1];
            f[2, 0] = temp2[2, 2];
            f[2, 1] = temp2[1, 2];
            f[2, 2] = temp2[0, 2];
        }
        private void ReverseF()
        {
            result.Add("F'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, f);
            temp[0] = u[2, 0];
            temp[1] = u[2, 1];
            temp[2] = u[2, 2];

            u[2, 0] = r[0, 0];
            u[2, 1] = r[1, 0];
            u[2, 2] = r[2, 0];

            r[0, 0] = d[0, 2];
            r[1, 0] = d[0, 1];
            r[2, 0] = d[0, 0];

            d[0, 2] = l[2, 2];
            d[0, 1] = l[1, 2];
            d[0, 0] = l[0, 2];

            l[2, 2] = temp[0];
            l[1, 2] = temp[1];
            l[0, 2] = temp[2];


            f[0, 0] = temp2[0, 2];
            f[0, 1] = temp2[1, 2];
            f[0, 2] = temp2[2, 2];
            f[1, 0] = temp2[0, 1];
            f[1, 1] = temp2[1, 1];
            f[1, 2] = temp2[2, 1];
            f[2, 0] = temp2[0, 0];
            f[2, 1] = temp2[1, 0];
            f[2, 2] = temp2[2, 0];
        }
        private void B()
        {
            result.Add("B");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, b);
            temp[0] = u[0, 0];
            temp[1] = u[0, 1];
            temp[2] = u[0, 2];

            u[0, 0] = r[0, 2];
            u[0, 1] = r[1, 2];
            u[0, 2] = r[2, 2];

            r[0, 2] = d[2, 2];
            r[1, 2] = d[2, 1];
            r[2, 2] = d[2, 0];

            d[2, 2] = l[2, 0];
            d[2, 1] = l[1, 0];
            d[2, 0] = l[0, 0];

            l[2, 0] = temp[0];
            l[1, 0] = temp[1];
            l[0, 0] = temp[2];


            b[0, 0] = temp2[2, 0];
            b[0, 1] = temp2[1, 0];
            b[0, 2] = temp2[0, 0];
            b[1, 0] = temp2[2, 1];
            b[1, 1] = temp2[1, 1];
            b[1, 2] = temp2[0, 1];
            b[2, 0] = temp2[2, 2];
            b[2, 1] = temp2[1, 2];
            b[2, 2] = temp2[0, 2];
        }
        private void ReverseB()
        {
            result.Add("B'");
            string[] temp = new string[3];
            string[,] temp2 = new string[3, 3];
            AssignBToA(temp2, b);
            temp[0] = u[0, 0];
            temp[1] = u[0, 1];
            temp[2] = u[0, 2];

            u[0, 0] = l[2, 0];
            u[0, 1] = l[1, 0];
            u[0, 2] = l[0, 0];

            l[2, 0] = d[2, 2];
            l[1, 0] = d[2, 1];
            l[0, 0] = d[2, 0];

            d[2, 2] = r[0, 2];
            d[2, 1] = r[1, 2];
            d[2, 0] = r[2, 2];

            r[0, 2] = temp[0];
            r[1, 2] = temp[1];
            r[2, 2] = temp[2];

            b[0, 0] = temp2[0, 2];
            b[0, 1] = temp2[1, 2];
            b[0, 2] = temp2[2, 2];
            b[1, 0] = temp2[0, 1];
            b[1, 1] = temp2[1, 1];
            b[1, 2] = temp2[2, 1];
            b[2, 0] = temp2[0, 0];
            b[2, 1] = temp2[1, 0];
            b[2, 2] = temp2[2, 0];
        }
        private void M()
        {
            result.Add("M");
            string[] temp = new string[3];
            temp[0] = u[0, 1];
            temp[1] = u[1, 1];
            temp[2] = u[2, 1];

            u[0, 1] = b[2, 1];
            u[1, 1] = b[1, 1];
            u[2, 1] = b[0, 1];

            b[2, 1] = d[0, 1];
            b[1, 1] = d[1, 1];
            b[0, 1] = d[2, 1];

            d[0, 1] = f[0, 1];
            d[1, 1] = f[1, 1];
            d[2, 1] = f[2, 1];

            f[0, 1] = temp[0];
            f[1, 1] = temp[1];
            f[2, 1] = temp[2];
        }
        private void ReverseM()
        {
            result.Add("M'");
            string[] temp = new string[3];
            temp[0] = u[0, 1];
            temp[1] = u[1, 1];
            temp[2] = u[2, 1];

            u[0, 1] = f[0, 1];
            u[1, 1] = f[1, 1];
            u[2, 1] = f[2, 1];

            f[0, 1] = d[0, 1];
            f[1, 1] = d[1, 1];
            f[2, 1] = d[2, 1];

            d[0, 1] = b[2, 1];
            d[1, 1] = b[1, 1];
            d[2, 1] = b[0, 1];

            b[2, 1] = temp[0];
            b[1, 1] = temp[1];
            b[0, 1] = temp[2];
        }
        private void MX()
        {
            result.Add("S");
            string[] temp = new string[3];
            temp[0] = u[1, 0];
            temp[1] = u[1, 1];
            temp[2] = u[1, 2];

            u[1, 0] = l[2, 1];
            u[1, 1] = l[1, 1];
            u[1, 2] = l[0, 1];

            l[2, 1] = d[1, 2];
            l[1, 1] = d[1, 1];
            l[0, 1] = d[1, 0];

            d[1, 2] = r[0, 1];
            d[1, 1] = r[1, 1];
            d[1, 0] = r[2, 1];

            r[0, 1] = temp[0];
            r[1, 1] = temp[1];
            r[2, 1] = temp[2];
        }
        private void ReverseMX()
        {
            result.Add("S'");
            string[] temp = new string[3];
            temp[0] = u[1, 0];
            temp[1] = u[1, 1];
            temp[2] = u[1, 2];

            u[1, 0] = r[0, 1];
            u[1, 1] = r[1, 1];
            u[1, 2] = r[2, 1];

            r[0, 1] = d[1, 2];
            r[1, 1] = d[1, 1];
            r[2, 1] = d[1, 0];

            d[1, 2] = l[2, 1];
            d[1, 1] = l[1, 1];
            d[1, 0] = l[0, 1];

            l[2, 1] = temp[0];
            l[1, 1] = temp[1];
            l[0, 1] = temp[2];
        }

        /*First Floor*/
        private void FindWhiteCross(out string location, out bool whiteCross)
        {
            location = "";
            whiteCross = false;
            /*If there is already a white cross on U side then our job here is done*/
            if (u[0, 1][0] == 'w' && u[1, 0][0] == 'w' && u[1, 2][0] == 'w' && u[2, 1][0] == 'w')
            {
                whiteCross = true;
            }
            else
            {

                //L side//
                if (l[0, 1][0] == 'w')
                {
                    location = "l01";
                    return;
                }
                if (l[1, 0][0] == 'w')
                {
                    location = "l10";
                    return;
                }
                if (l[1, 2][0] == 'w')
                {
                    location = "l12";
                    return;
                }
                if (l[2, 1][0] == 'w')
                {
                    location = "l21";
                    return;
                }
                //F side//
                if (f[0, 1][0] == 'w')
                {
                    location = "f01";
                    return;
                }
                if (f[1, 0][0] == 'w')
                {
                    location = "f10";
                    return;
                }
                if (f[1, 2][0] == 'w')
                {
                    location = "f12";
                    return;
                }
                if (f[2, 1][0] == 'w')
                {
                    location = "f21";
                    return;
                }
                //R side//
                if (r[0, 1][0] == 'w')
                {
                    location = "r01";
                    return;
                }
                if (r[1, 0][0] == 'w')
                {
                    location = "r10";
                    return;
                }
                if (r[1, 2][0] == 'w')
                {
                    location = "r12";
                    return;
                }
                if (r[2, 1][0] == 'w')
                {
                    location = "r21";
                    return;
                }
                //B side//
                if (b[0, 1][0] == 'w')
                {
                    location = "b01";
                    return;
                }
                if (b[1, 0][0] == 'w')
                {
                    location = "b10";
                    return;
                }
                if (b[1, 2][0] == 'w')
                {
                    location = "b12";
                    return;
                }
                if (b[2, 1][0] == 'w')
                {
                    location = "b21";
                    return;
                }
                //D side//
                if (d[0, 1][0] == 'w')
                {
                    location = "d01";
                    return;
                }
                if (d[1, 0][0] == 'w')
                {
                    location = "d10";
                    return;
                }
                if (d[1, 2][0] == 'w')
                {
                    location = "d12";
                    return;
                }
                if (d[2, 1][0] == 'w')
                {
                    location = "d21";
                    return;
                }
            }
        }
        private void MakeWhiteCross(string location)
        {
            if (location[0] == 'l')
            {
                if (location[1] == '0' && location[2] == '1')
                {
                    L();
                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    F();
                }
                else if (location[1] == '1' && location[2] == '0')
                {
                    while (u[0, 1][0] == 'w')
                    {
                        U();
                    }
                    ReverseB();
                }
                else if (location[1] == '1' && location[2] == '2')
                {
                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    F();
                }
                else
                {
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    L();
                    U();
                    ReverseB();
                }
            }
            else if (location[0] == 'f')
            {
                if (location[1] == '0' && location[2] == '1')
                {
                    F();
                    while (u[1, 2][0] == 'w')
                    {
                        U();
                    }
                    R();
                }
                else if (location[1] == '1' && location[2] == '0')
                {
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    ReverseL();
                }
                else if (location[1] == '1' && location[2] == '2')
                {
                    while (u[1, 2][0] == 'w')
                    {
                        U();
                    }
                    R();
                }
                else
                {
                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    F();
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    ReverseL();
                }
            }
            else if (location[0] == 'r')
            {
                if (location[1] == '0' && location[2] == '1')
                {
                    ReverseR();
                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    ReverseF();
                }
                else if (location[1] == '1' && location[2] == '0')
                {
                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    ReverseF();
                }
                else if (location[1] == '1' && location[2] == '2')
                {
                    while (u[0, 1][0] == 'w')
                    {
                        U();
                    }
                    B();
                }
                else
                {
                    while (u[1, 2][0] == 'w')
                    {
                        U();
                    }
                    ReverseR();
                    while (u[0, 1][0] == 'w')
                    {
                        U();
                    }
                    B();
                }
            }
            else if (location[0] == 'b')
            {
                if (location[1] == '0' && location[2] == '1')
                {
                    B();
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    L();
                }
                else if (location[1] == '1' && location[2] == '0')
                {
                    while (u[1, 2][0] == 'w')
                    {
                        U();
                    }
                    ReverseR();
                }
                else if (location[1] == '1' && location[2] == '2')
                {
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    L();
                }
                else
                {
                    while (u[0, 1][0] == 'w')
                    {
                        U();
                    }
                    B();
                    U();
                    ReverseR();
                }
            }
            else
            {
                if (location[1] == '0' && location[2] == '1')
                {

                    while (u[2, 1][0] == 'w')
                    {
                        U();
                    }
                    F();
                    F();
                }
                else if (location[1] == '1' && location[2] == '0')
                {
                    while (u[1, 0][0] == 'w')
                    {
                        U();
                    }
                    L();
                    L();
                }
                else if (location[1] == '1' && location[2] == '2')
                {
                    while (u[1, 2][0] == 'w')
                    {
                        U();
                    }
                    R();
                    R();
                }
                else
                {
                    while (u[0, 1][0] == 'w')
                    {
                        U();
                    }
                    B();
                    B();
                }
            }
        }
        private bool FindCorrectWhiteCross()
        {
            if (f[0, 1][0] == f[1, 1][0] && l[0, 1][0] == l[1, 1][0] || l[0, 1][0] == l[1, 1][0] && b[0, 1][0] == b[1, 1][0] || b[0, 1][0] == b[1, 1][0] && r[0, 1][0] == r[1, 1][0]
                || r[0, 1][0] == r[1, 1][0] && f[0, 1][0] == f[1, 1][0] || f[0, 1][0] == f[1, 1][0] && b[0, 1][0] == b[1, 1][0] || l[0, 1][0] == l[1, 1][0] && r[0, 1][0] == r[1, 1][0])
                return true;

            return false;
        }
        private void CorrectWhiteCross()
        {
            if (f[1, 1][0] == f[0, 1][0] && l[1, 1][0] == l[0, 1][0])
            {
                ReverseB();
                ReverseU();
                B();
                U();
                ReverseB();
            }
            else if (l[1, 1][0] == l[0, 1][0] && b[1, 1][0] == b[0, 1][0])
            {
                ReverseR();
                ReverseU();
                R();
                U();
                ReverseR();
            }
            else if (b[1, 1][0] == b[0, 1][0] && r[1, 1][0] == r[0, 1][0])
            {
                ReverseF();
                ReverseU();
                F();
                U();
                ReverseF();
            }
            else if (r[1, 1][0] == r[0, 1][0] && f[1, 1][0] == f[0, 1][0])
            {
                ReverseL();
                ReverseU();
                L();
                U();
                ReverseL();
            }
            else if (f[1, 1][0] == f[0, 1][0] && b[1, 1][0] == b[0, 1][0])
            {
                MX();
                R();
                R();
                ReverseMX();
            }
            else
            {
                M();
                F();
                F();
                ReverseM();
            }
        }
        private void FindWhiteCorner(out string location, out bool correctedCorner)
        {
            location = "";
            correctedCorner = false;
            if (u[0, 0][0] == 'w' && u[0, 2][0] == 'w' && u[2, 0][0] == 'w' && u[2, 2][0] == 'w')
            {
                correctedCorner = true;
            }
            else
            {
                //L side
                if (l[0, 0][0] == 'w')
                {
                    location = "l00";
                    return;
                }

                if (l[0, 2][0] == 'w')
                {
                    location = "l02";
                    return;
                }

                if (l[2, 0][0] == 'w')
                {
                    location = "l20";
                    return;
                }

                if (l[2, 2][0] == 'w')
                {
                    location = "l22";
                    return;
                }
                //F side
                if (f[0, 0][0] == 'w')
                {
                    location = "f00";
                    return;
                }

                if (f[0, 2][0] == 'w')
                {
                    location = "f02";
                    return;
                }

                if (f[2, 0][0] == 'w')
                {
                    location = "f20";
                    return;
                }

                if (f[2, 2][0] == 'w')
                {
                    location = "f22";
                    return;
                }
                //R side
                if (r[0, 0][0] == 'w')
                {
                    location = "r00";
                    return;
                }

                if (r[0, 2][0] == 'w')
                {
                    location = "r02";
                    return;
                }

                if (r[2, 0][0] == 'w')
                {
                    location = "r20";
                    return;
                }

                if (r[2, 2][0] == 'w')
                {
                    location = "r22";
                    return;
                }
                //B side
                if (b[0, 0][0] == 'w')
                {
                    location = "b00";
                    return;
                }

                if (b[0, 2][0] == 'w')
                {
                    location = "b02";
                    return;
                }

                if (b[2, 0][0] == 'w')
                {
                    location = "b20";
                    return;
                }

                if (b[2, 2][0] == 'w')
                {
                    location = "b22";
                    return;
                }
                //D side
                if (d[0, 0][0] == 'w')
                {
                    location = "d00";
                    return;
                }

                if (d[0, 2][0] == 'w')
                {
                    location = "d02";
                    return;
                }

                if (d[2, 0][0] == 'w')
                {
                    location = "d20";
                    return;
                }

                if (d[2, 2][0] == 'w')
                {
                    location = "d22";
                }
            }
        }
        private void PlaceCorner(string location)
        {
            if (location[0] == 'l')
            {
                if (location[1] == '0' && location[2] == '0')
                {
                    ReverseL();
                    ReverseD();
                    L();
                    ReverseD();
                    B();
                    D();
                    D();
                    ReverseB();
                }
                else if (location[1] == '0' && location[2] == '2')
                {
                    L();
                    D();
                    ReverseL();
                    D();
                    ReverseF();
                    D();
                    D();
                    F();
                }
                else if (location[1] == '2' && location[2] == '0')
                {
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        B();
                        ReverseD();
                        ReverseB();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        D();
                        D();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    else
                    {
                        F();
                        D();
                        D();
                        ReverseF();
                    }
                }
                else
                {
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        D();
                        ReverseL();
                        D();
                        L();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        ReverseB();
                        D();
                        D();
                        B();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        ReverseD();
                        ReverseF();
                        D();
                        F();
                    }
                    else
                    {
                        ReverseR();
                        D();
                        R();
                    }
                }

            }
            else if (location[0] == 'f')
            {
                if (location[1] == '0' && location[2] == '0')
                {
                    ReverseF();
                    ReverseD();
                    F();
                    D();
                    D();
                    L();
                    ReverseD();
                    ReverseL();
                }
                else if (location[1] == '0' && location[2] == '2')
                {
                    F();
                    D();
                    D();
                    ReverseF();
                    ReverseR();
                    D();
                    D();
                    R();
                }
                else if (location[1] == '2' && location[2] == '0')
                {
                    ReverseD();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        B();
                        ReverseD();
                        ReverseB();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        D();
                        D();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    else
                    {
                        F();
                        D();
                        D();
                        ReverseF();
                    }
                }
                else
                {
                    ReverseD();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        D();
                        ReverseL();
                        D();
                        L();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        ReverseB();
                        D();
                        D();
                        B();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        ReverseD();
                        ReverseF();
                        D();
                        F();
                    }
                    else
                    {
                        ReverseR();
                        D();
                        R();
                    }
                }
            }
            else if (location[0] == 'r')
            {
                if (location[1] == '0' && location[2] == '0')
                {
                    ReverseR();
                    D();
                    D();
                    R();
                    F();
                    D();
                    D();
                    ReverseF();
                }
                else if (location[1] == '0' && location[2] == '2')
                {
                    R();
                    D();
                    D();
                    ReverseR();
                    ReverseB();
                    D();
                    D();
                    B();
                }
                else if (location[1] == '2' && location[2] == '0')
                {
                    D();
                    D();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        B();
                        ReverseD();
                        ReverseB();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        D();
                        D();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    else
                    {
                        F();
                        D();
                        D();
                        ReverseF();
                    }
                }
                else
                {
                    D();
                    D();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        D();
                        ReverseL();
                        D();
                        L();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        ReverseB();
                        D();
                        D();
                        B();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        ReverseD();
                        ReverseF();
                        D();
                        F();
                    }
                    else
                    {
                        ReverseR();
                        D();
                        R();
                    }
                }
            }
            else if (location[0] == 'b')
            {
                if (location[1] == '0' && location[2] == '0')
                {
                    ReverseB();
                    D();
                    D();
                    B();
                    R();
                    D();
                    D();
                    ReverseR();
                }
                else if (location[1] == '0' && location[2] == '2')
                {
                    B();
                    D();
                    D();
                    ReverseB();
                    ReverseL();
                    D();
                    D();
                    L();
                }
                else if (location[1] == '2' && location[2] == '0')
                {
                    D();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        B();
                        ReverseD();
                        ReverseB();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        D();
                        D();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    else
                    {
                        F();
                        D();
                        D();
                        ReverseF();
                    }
                }
                else
                {
                    D();
                    if (u[0, 0][0] != 'w')
                    {
                        D();
                        D();
                        ReverseL();
                        D();
                        L();
                    }
                    else if (u[0, 2][0] != 'w')
                    {
                        ReverseB();
                        D();
                        D();
                        B();
                    }
                    else if (u[2, 0][0] != 'w')
                    {
                        ReverseD();
                        ReverseF();
                        D();
                        F();
                    }
                    else
                    {
                        ReverseR();
                        D();
                        R();
                    }
                }
            }
            else
            {
                if (location[1] == '0' && location[2] == '0')
                {
                    int times = 0;
                    while (u[2, 0][0] == 'w')
                    {
                        U();
                        times++;
                    }
                    L();
                    D();
                    D();
                    ReverseL();
                    for (int i = 0; i < times; i++)
                    {
                        ReverseU();
                    }
                }
                else if (location[1] == '0' && location[2] == '2')
                {
                    int times = 0;
                    while (u[2, 2][0] == 'w')
                    {
                        U();
                        times++;
                    }
                    ReverseR();
                    D();
                    R();
                    for (int i = 0; i < times; i++)
                    {
                        ReverseU();
                    }
                }
                else if (location[1] == '2' && location[2] == '0')
                {
                    int times = 0;
                    while (u[0, 0][0] == 'w')
                    {
                        U();
                        times++;
                    }
                    ReverseL();
                    D();
                    L();
                    for (int i = 0; i < times; i++)
                    {
                        ReverseU();
                    }
                }
                else
                {
                    int times = 0;
                    while (u[0, 2][0] == 'w')
                    {
                        U();
                        times++;
                    }
                    R();
                    ReverseD();
                    ReverseR();
                    for (int i = 0; i < times; i++)
                    {
                        ReverseU();
                    }
                }
            }

        }
        private bool WhiteCornerCondition()
        {
            if (u[0, 0] == "w1" && u[0, 2] == "w3" && u[2, 0] == "w7" && u[2, 2] == "w9")
            {
                return true;
            }

            return false;
        }
        //Now we need 6 Swap Method
        private void Swap(int whatToDo)
        {
            switch (whatToDo)
            {
                //Swap u[0,0] -> u[2,2]
                case 1:
                    {
                        ReverseR();
                        D();
                        R();
                        B();
                        D();
                        D();
                        ReverseB();
                        ReverseR();
                        ReverseD();
                        R();
                    }
                    break;
                //Swap u[0,0] -> u[2,0]
                case 2:
                    {
                        ReverseF();
                        D();
                        D();
                        F();
                        ReverseL();
                        D();
                        L();
                        D();
                        D();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    break;
                //Swap u[2,0] -> u[2,2]
                case 3:
                    {
                        L();
                        D();
                        ReverseL();
                        ReverseR();
                        ReverseD();
                        R();
                        L();
                        D();
                        ReverseL();
                    }
                    break;
                //Swap u[0,2] -> u[2,0]
                case 4:
                    {
                        L();
                        ReverseD();
                        ReverseL();
                        ReverseB();
                        D();
                        D();
                        B();
                        L();
                        D();
                        ReverseL();
                    }
                    break;
                //Swap u[0,2] -> u[2,2]
                case 5:
                    {
                        ReverseR();
                        ReverseD();
                        R();
                        ReverseB();
                        D();
                        D();
                        B();
                        ReverseR();
                        D();
                        R();

                    }
                    break;
                //Swap u[0,0] -> u[0,2]
                case 6:
                    {
                        R();
                        ReverseD();
                        ReverseR();
                        ReverseL();
                        D();
                        L();
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    break;
            }
        }
        private void CorrectWhiteCorner()
        {
            //u[0,0] != "w1"
            if (u[0, 0] == "w3")
            {
                Swap(6);
            }
            if (u[0, 0] == "w7")
            {
                Swap(2);
            }
            if (u[0, 0] == "w9")
            {
                Swap(1);
            }
            //u[0,2] != "w3"
            if (u[0, 2] == "w1")
            {
                Swap(6);
            }
            if (u[0, 2] == "w7")
            {
                Swap(4);
            }
            if (u[0, 2] == "w9")
            {
                Swap(5);
            }
            //u[2,0] != "w7"

            if (u[2, 0] == "w3")
            {
                Swap(4);
            }
            if (u[2, 0] == "w1")
            {
                Swap(2);
            }
            if (u[2, 0] == "w9")
            {
                Swap(3);
            }
            //u[2,2] != "w9"

            if (u[2, 2] == "w3")
            {
                Swap(5);
            }
            if (u[2, 2] == "w1")
            {
                Swap(1);
            }
            if (u[2, 2] == "w7")
            {
                Swap(3);
            }

        }
        private void SolveFirstFloor()
        {
            //Just assume that we don't have a white cross yet//
            bool whiteCrossNone = true;
            bool whiteCross = false;
            string location;
            //So we have to spin the cube until we have a white cross//
            while (whiteCrossNone)
            {
                /*First we find the location of white mid one
                 if we already have a white cross then it will return whiteCross = true;
                 */
                FindWhiteCross(out location, out whiteCross);
                //So it will run this line//
                if (whiteCross)
                {
                    whiteCrossNone = false;
                }
                /*and when it happens whiteCrossNone will be false and we will get
                 out of the while method and go to the next step */

                /*Else, we will get to this line and we'll place one white mid cube to it right place and then repeat
                 Find location -> Check if there is a white cross or not -> Place one white mid cube to it right place -> Repeat
                 */
                else
                {
                    MakeWhiteCross(location);
                }
            }
            while (!FindCorrectWhiteCross())
            {
                U();
            }
            //In case we already have a perfect white cross we don't have to correct it.
            if (!(f[0, 1][0] == f[1, 1][0] && l[0, 1][0] == l[1, 1][0] && b[0, 1][0] == b[1, 1][0] && r[0, 1][0] == r[1, 1][0]))
            {
                CorrectWhiteCross();
            }

            //The same with these steps below//

            bool whiteCornerNone = true;
            bool whiteCorner = false;
            //We find and place those in corner it could be wrong but doesn't matter.
            while (whiteCornerNone)
            {
                FindWhiteCorner(out location, out whiteCorner);
                if (whiteCorner)
                {
                    whiteCornerNone = false;
                }
                else
                {
                    PlaceCorner(location);
                }
            }
            // We will correct it here.
            while (!WhiteCornerCondition())
            {
                CorrectWhiteCorner();
            }
        }
        //

        /*Second Floor*/
        private void FindSecondFloor(out string location, out bool corrected)
        {
            location = "";
            corrected = false;
            //You only need to sovle Front & Back or Left & Right
            if (f[1, 0] == "g4" && f[1, 2] == "g6" && b[1, 0] == "b4" && b[1, 2] == "b6")
            {
                corrected = true;
            }
            else
            {
                //We will try to solve Front side then Back
                //By finding the green one at [2,1]
                if (l[2, 1] == "g4" || l[2, 1] == "g6")
                {
                    location = "gl21";
                    return;
                }
                if (f[2, 1] == "g4" || f[2, 1] == "g6")
                {
                    location = "gf21";
                    return;
                }
                if (r[2, 1] == "g4" || r[2, 1] == "g6")
                {
                    location = "gr21";
                    return;
                }
                if (b[2, 1] == "g4" || b[2, 1] == "g6")
                {
                    location = "gb21";
                    return;
                }
                if (d[0, 1] == "g4" || d[0, 1] == "g6")
                {
                    location = "gd01";
                    return;
                }
                if (d[1, 0] == "g4" || d[1, 0] == "g6")
                {
                    location = "gd10";
                    return;
                }
                if (d[1, 2] == "g4" || d[1, 2] == "g6")
                {
                    location = "gd12";
                    return;
                }
                if (d[2, 1] == "g4" || d[2, 1] == "g6")
                {
                    location = "gd21";
                    return;
                }
                //In case the green one is in the second floor but wrong position
                if (l[1, 0] == "g4" || l[1, 0] == "g6")
                {
                    location = "gl10";
                    return;
                }
                if (l[1, 2] == "g4" || l[1, 2] == "g6")
                {
                    location = "gl12";
                    return;
                }
                if (f[1, 0] == "g4" || f[1, 0] == "g6")
                {
                    if (f[1, 0] != "g4")
                    {
                        location = "gf10";
                        return;
                    }
                }
                if (f[1, 2] == "g4" || f[1, 2] == "g6")
                {
                    if (f[1, 2] != "g6")
                    {
                        location = "gf12";
                        return;
                    }
                }
                if (r[1, 0] == "g4" || r[1, 0] == "g6")
                {
                    location = "gr10";
                    return;
                }
                if (r[1, 2] == "g4" || r[1, 2] == "g6")
                {
                    location = "gr12";
                    return;
                }
                if (b[1, 0] == "g4" || b[1, 0] == "g6")
                {
                    location = "gb10";
                    return;
                }
                if (b[1, 2] == "g4" || b[1, 2] == "g6")
                {
                    location = "gb12";
                    return;
                }
                //Go on to the blue one
                if (l[2, 1] == "b4" || l[2, 1] == "b6")
                {
                    location = "bl21";
                    return;
                }
                if (f[2, 1] == "b4" || f[2, 1] == "b6")
                {
                    location = "bf21";
                    return;
                }
                if (r[2, 1] == "b4" || r[2, 1] == "b6")
                {
                    location = "br21";
                    return;
                }
                if (b[2, 1] == "b4" || b[2, 1] == "b6")
                {
                    location = "bb21";
                    return;
                }
                if (d[0, 1] == "b4" || d[0, 1] == "b6")
                {
                    location = "bd01";
                    return;
                }
                if (d[1, 0] == "b4" || d[1, 0] == "b6")
                {
                    location = "bd10";
                    return;
                }
                if (d[1, 2] == "b4" || d[1, 2] == "b6")
                {
                    location = "bd12";
                    return;
                }
                if (d[2, 1] == "b4" || d[2, 1] == "b6")
                {
                    location = "bd21";
                    return;
                }
                //In case the blue one is in the second floor but wrong position
                if (l[1, 0] == "b4" || l[1, 0] == "b6")
                {
                    location = "bl10";
                    return;
                }
                if (l[1, 2] == "b4" || l[1, 2] == "b6")
                {
                    location = "bl12";
                    return;
                }
                if (f[1, 0] == "b4" || f[1, 0] == "b6")
                {
                    location = "bf10";
                    return;
                }
                if (f[1, 2] == "b4" || f[1, 2] == "b6")
                {
                    location = "bf12";
                    return;
                }
                if (r[1, 0] == "b4" || r[1, 0] == "b6")
                {
                    location = "br10";
                    return;
                }
                if (r[1, 2] == "b4" || r[1, 2] == "b6")
                {
                    location = "br12";
                    return;
                }
                if (b[1, 0] == "b4" || b[1, 0] == "b6")
                {
                    if (b[1, 0] != "b4")
                    {
                        location = "bb10";
                        return;
                    }
                }
                if (b[1, 2] == "b4" || b[1, 2] == "b6")
                {
                    if (b[1, 2] != "b4")
                    {
                        location = "bb12";
                    }
                }

            }
        }
        private void EightSpinMethods(char side, char lor)
        {
            switch (side)
            {
                case 'f':
                    {
                        if (lor == 'r')
                        {
                            ReverseD();
                            ReverseR();
                            D();
                            R();
                            D();
                            F();
                            ReverseD();
                            ReverseF();
                        }
                        else
                        {
                            D();
                            L();
                            ReverseD();
                            ReverseL();
                            ReverseD();
                            ReverseF();
                            D();
                            F();
                        }
                    }
                    break;
                case 'b':
                    {
                        if (lor == 'r')
                        {
                            ReverseD();
                            ReverseL();
                            D();
                            L();
                            D();
                            B();
                            ReverseD();
                            ReverseB();
                        }
                        else
                        {
                            D();
                            R();
                            ReverseD();
                            ReverseR();
                            ReverseD();
                            ReverseB();
                            D();
                            B();
                        }
                    }
                    break;
                case 'l':
                    {
                        if (lor == 'r')
                        {
                            ReverseD();
                            ReverseF();
                            D();
                            F();
                            D();
                            L();
                            ReverseD();
                            ReverseL();
                        }
                        else
                        {
                            D();
                            B();
                            ReverseD();
                            ReverseB();
                            ReverseD();
                            ReverseL();
                            D();
                            L();
                        }
                    }
                    break;
                case 'r':
                    {
                        if (lor == 'r')
                        {
                            ReverseD();
                            ReverseB();
                            D();
                            B();
                            D();
                            R();
                            ReverseD();
                            ReverseR();
                        }
                        else
                        {
                            D();
                            F();
                            ReverseD();
                            ReverseF();
                            ReverseD();
                            ReverseR();
                            D();
                            R();
                        }
                    }
                    break;
            }
        }
        private void CorrectSecondFloor(string location)
        {
            switch (location[0])
            {
                case 'g':
                    {
                        if (location[1] == 'l')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('l', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('l', 'r');
                            }
                            else
                            {
                                D();
                                if (f[2, 1] == "g4")
                                {
                                    EightSpinMethods('f', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('f', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'f')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                if (f[1, 0] != "g4")
                                {
                                    EightSpinMethods('f', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                if (f[1, 2] != "g6")
                                {
                                    EightSpinMethods('f', 'r');
                                }
                            }
                            else
                            {
                                if (f[2, 1] == "g4")
                                {
                                    EightSpinMethods('f', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('f', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'r')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('r', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('r', 'r');
                            }
                            else
                            {
                                ReverseD();
                                if (f[2, 1] == "g4")
                                {
                                    EightSpinMethods('f', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('f', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'b')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('b', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('b', 'r');
                            }
                            else
                            {
                                D();
                                D();
                                if (f[2, 1] == "g4")
                                {
                                    EightSpinMethods('f', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('f', 'r');
                                }
                            }
                        }
                        else
                        {
                            if (location[2] == '0' && location[3] == '1')
                            {
                                if (d[0, 1] == "g4")
                                {
                                    ReverseD();
                                    EightSpinMethods('l', 'r');
                                }
                                else
                                {
                                    D();
                                    EightSpinMethods('r', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '0')
                            {
                                if (d[1, 0] == "g4")
                                {
                                    EightSpinMethods('l', 'r');
                                }
                                else
                                {
                                    D();
                                    D();
                                    EightSpinMethods('r', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                if (d[1, 2] == "g4")
                                {
                                    D();
                                    D();
                                    EightSpinMethods('l', 'r');
                                }
                                else
                                {
                                    EightSpinMethods('r', 'l');
                                }
                            }
                            else
                            {
                                if (d[2, 1] == "g4")
                                {
                                    D();
                                    EightSpinMethods('l', 'r');
                                }
                                else
                                {
                                    ReverseD();
                                    EightSpinMethods('r', 'l');
                                }
                            }
                        }
                    }
                    break;

                case 'b':
                    {
                        if (location[1] == 'l')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('l', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('l', 'r');
                            }
                            else
                            {
                                ReverseD();
                                if (b[2, 1] == "b4")
                                {
                                    EightSpinMethods('b', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('b', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'f')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('f', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('f', 'r');
                            }
                            else
                            {
                                D();
                                D();
                                if (b[2, 1] == "b4")
                                {
                                    EightSpinMethods('b', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('b', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'r')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                EightSpinMethods('r', 'l');
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                EightSpinMethods('r', 'r');
                            }
                            else
                            {
                                D();
                                if (b[2, 1] == "b4")
                                {
                                    EightSpinMethods('b', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('b', 'r');
                                }
                            }
                        }
                        else if (location[1] == 'b')
                        {
                            if (location[2] == '1' && location[3] == '0')
                            {
                                if (b[1, 0] != "b4")
                                {
                                    EightSpinMethods('b', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                if (b[1, 2] != "g6")
                                {
                                    EightSpinMethods('b', 'r');
                                }
                            }
                            else
                            {
                                if (b[2, 1] == "b4")
                                {
                                    EightSpinMethods('b', 'l');
                                }
                                else
                                {
                                    EightSpinMethods('b', 'r');
                                }
                            }
                        }
                        else
                        {
                            if (location[2] == '0' && location[3] == '1')
                            {
                                if (d[0, 1] == "b4")
                                {
                                    D();
                                    EightSpinMethods('r', 'r');
                                }
                                else
                                {
                                    ReverseD();
                                    EightSpinMethods('l', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '0')
                            {
                                if (d[1, 0] == "b4")
                                {
                                    D();
                                    D();
                                    EightSpinMethods('r', 'r');
                                }
                                else
                                {
                                    EightSpinMethods('l', 'l');
                                }
                            }
                            else if (location[2] == '1' && location[3] == '2')
                            {
                                if (d[1, 2] == "b4")
                                {
                                    EightSpinMethods('r', 'r');
                                }
                                else
                                {
                                    D();
                                    D();
                                    EightSpinMethods('l', 'l');
                                }
                            }
                            else
                            {
                                if (d[2, 1] == "b4")
                                {
                                    ReverseD();
                                    EightSpinMethods('r', 'r');
                                }
                                else
                                {
                                    D();
                                    EightSpinMethods('l', 'l');
                                }
                            }
                        }
                    }
                    break;
            }
        }
        private void SolveSecondFloor()
        {
            string location;
            bool corrected;
            bool repeatTillDone = true;
            while (repeatTillDone)
            {
                FindSecondFloor(out location, out corrected);
                if (corrected)
                {
                    repeatTillDone = false;
                }
                else
                {
                    CorrectSecondFloor(location);
                }
            }
        }
        //

        /*Third Floor*/
        private void MakeYellowCross()
        {
            if (d[0, 1][0] != 'y' && d[1, 0][0] != 'y' && d[1, 2][0] != 'y' && d[2, 1][0] != 'y')
            {
                F();
                L();
                D();
                ReverseL();
                ReverseD();
                ReverseF();
            }
            else
            {
                if (d[0, 1][0] == 'y' && d[1, 2][0] == 'y' && d[1, 0][0] != 'y' && d[2, 1][0] != 'y')
                {
                    D();
                }
                else if (d[2, 1][0] == 'y' && d[1, 2][0] == 'y' && d[1, 0][0] != 'y' && d[0, 1][0] != 'y')
                {
                    F();
                    L();
                    D();
                    ReverseL();
                    ReverseD();
                    L();
                    D();
                    ReverseL();
                    ReverseD();
                    ReverseF();
                }
                else if (d[2, 1][0] == 'y' && d[1, 0][0] == 'y' && d[0, 1][0] != 'y' && d[1, 2][0] != 'y')
                {
                    ReverseD();
                }
                else if (d[0, 1][0] == 'y' && d[1, 0][0] == 'y' && d[1, 2][0] != 'y' && d[2, 1][0] != 'y')
                {
                    D();
                    D();
                }
                else if (d[1, 0][0] == 'y' && d[1, 2][0] == 'y' && d[0, 1][0] != 'y' && d[2, 1][0] != 'y')
                {
                    F();
                    L();
                    D();
                    ReverseL();
                    ReverseD();
                    ReverseF();
                }
                else
                {
                    D();
                    F();
                    L();
                    D();
                    ReverseL();
                    ReverseD();
                    ReverseF();
                }
            }
        }
        private void CompleteDSide()
        {
            if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && f[2, 0][0] == 'y')
            {
                L();
                D();
                ReverseL();
                D();
                L();
                D();
                D();
                ReverseL();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] == 'y' && r[2, 0][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && b[2, 0][0] == 'y')
            {
                D();
                D();
            }
            else if (d[0, 0][0] == 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && l[2, 0][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] == 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && f[2, 2][0] == 'y')
            {
                ReverseR();
                ReverseD();
                R();
                ReverseD();
                ReverseR();
                D();
                D();
                R();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && r[2, 2][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] == 'y' && b[2, 2][0] == 'y')
            {
                D();
                D();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && l[2, 2][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && f[2, 0][0] == 'y' && b[2, 2][0] == 'y' && r[2, 0][0] == 'y' && r[2, 2][0] == 'y')
            {
                B();
                D();
                R();
                ReverseD();
                ReverseR();
                F();
                ReverseB();
                L();
                D();
                ReverseL();
                ReverseD();
                ReverseF();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && r[2, 0][0] == 'y' && l[2, 2][0] == 'y' && b[2, 0][0] == 'y' && b[2, 2][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && b[2, 0][0] == 'y' && f[2, 2][0] == 'y' && l[2, 0][0] == 'y' && l[2, 2][0] == 'y')
            {
                D();
                D();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && l[2, 0][0] == 'y' && r[2, 2][0] == 'y' && f[2, 0][0] == 'y' && f[2, 2][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] == 'y' && d[2, 2][0] == 'y' && f[2, 0][0] == 'y' && f[2, 2][0] == 'y')
            {
                L();
                L();
                U();
                ReverseL();
                D();
                D();
                L();
                ReverseU();
                ReverseL();
                D();
                D();
                ReverseL();
            }
            else if (d[0, 0][0] == 'y' && d[0, 2][0] != 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && r[2, 0][0] == 'y' && r[2, 2][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] == 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && b[2, 0][0] == 'y' && b[2, 2][0] == 'y')
            {
                D();
                D();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] == 'y' && l[2, 0][0] == 'y' && l[2, 2][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] == 'y' && d[0, 2][0] != 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && f[2, 2][0] == 'y' && b[2, 0][0] == 'y')
            {
                R();
                F();
                ReverseL();
                ReverseF();
                ReverseR();
                F();
                L();
                ReverseF();
            }
            else if (d[0, 0][0] == 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && r[2, 2][0] == 'y' && l[2, 0][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] != 'y' && d[2, 2][0] == 'y' && b[2, 2][0] == 'y' && f[2, 0][0] == 'y')
            {
                D();
                D();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] == 'y' && d[2, 2][0] == 'y' && l[2, 2][0] == 'y' && r[2, 0][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && f[2, 0][0] == 'y' && f[2, 2][0] == 'y' && b[2, 0][0] == 'y' && b[2, 2][0] == 'y')
            {
                F();
                L();
                D();
                ReverseL();
                ReverseD();
                L();
                D();
                ReverseL();
                ReverseD();
                L();
                D();
                ReverseL();
                ReverseD();
                ReverseF();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] != 'y' && l[2, 0][0] == 'y' && l[2, 2][0] == 'y' && r[2, 0][0] == 'y' && r[2, 2][0] == 'y')
            {
                D();
            }

            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && f[2, 0][0] == 'y' && r[2, 2][0] == 'y')
            {
                ReverseF();
                R();
                F();
                ReverseL();
                ReverseF();
                ReverseR();
                F();
                L();
            }
            else if (d[0, 0][0] == 'y' && d[0, 2][0] != 'y' && d[2, 0][0] != 'y' && d[2, 2][0] == 'y' && r[2, 0][0] == 'y' && b[2, 2][0] == 'y')
            {
                ReverseD();
            }
            else if (d[0, 0][0] != 'y' && d[0, 2][0] == 'y' && d[2, 0][0] == 'y' && d[2, 2][0] != 'y' && b[2, 0][0] == 'y' && l[2, 2][0] == 'y')
            {
                D();
                D();
            }
            else
            {
                D();
            }

        }
        private void FourSpinMethod(char side)
        {
            switch (side)
            {
                case 'f':
                    {
                        B();
                        D();
                        ReverseB();
                        ReverseL();
                        B();
                        D();
                        ReverseB();
                        ReverseD();
                        ReverseB();
                        L();
                        B();
                        B();
                        ReverseD();
                        ReverseB();
                    }
                    break;
                case 'l':
                    {
                        R();
                        D();
                        ReverseR();
                        ReverseB();
                        R();
                        D();
                        ReverseR();
                        ReverseD();
                        ReverseR();
                        B();
                        R();
                        R();
                        ReverseD();
                        ReverseR();
                    }
                    break;
                case 'r':
                    {
                        L();
                        D();
                        ReverseL();
                        ReverseF();
                        L();
                        D();
                        ReverseL();
                        ReverseD();
                        ReverseL();
                        F();
                        L();
                        L();
                        ReverseD();
                        ReverseL();
                    }
                    break;
                case 'b':
                    {
                        F();
                        D();
                        ReverseF();
                        ReverseR();
                        F();
                        D();
                        ReverseF();
                        ReverseD();
                        ReverseF();
                        R();
                        F();
                        F();
                        ReverseD();
                        ReverseF();
                    }
                    break;

            }
        }
        private void MakeFinalCondition()
        {
            if (!(f[2, 0][0] == f[2, 2][0] && r[2, 0][0] == r[2, 2][0] && b[2, 0][0] == b[2, 2][0] && l[2, 0][0] == l[2, 2][0]))
            {
                if (f[2, 0][0] != f[2, 2][0] && r[2, 0][0] != r[2, 2][0] && b[2, 0][0] != b[2, 2][0] && l[2, 0][0] != l[2, 2][0])
                {
                    FourSpinMethod('r');
                }
                else
                {
                    if (f[2, 0][0] == f[2, 2][0])
                    {
                        if (f[2, 0][0] == 'g')
                        {
                            FourSpinMethod('f');
                        }
                        else if (f[2, 0][0] == 'r')
                        {
                            D();
                            FourSpinMethod('r');
                        }
                        else if (f[2, 0][0] == 'b')
                        {
                            D();
                            D();
                            FourSpinMethod('b');
                        }
                        else
                        {
                            ReverseD();
                            FourSpinMethod('l');
                        }
                    }
                    else if (r[2, 0][0] == r[2, 2][0])
                    {
                        if (r[2, 0][0] == 'g')
                        {
                            ReverseD();
                            FourSpinMethod('f');
                        }
                        else if (r[2, 0][0] == 'r')
                        {
                            FourSpinMethod('r');
                        }
                        else if (r[2, 0][0] == 'b')
                        {
                            D();
                            FourSpinMethod('b');
                        }
                        else
                        {
                            D();
                            D();
                            FourSpinMethod('l');
                        }
                    }
                    else if (b[2, 0][0] == b[2, 2][0])
                    {
                        if (b[2, 0][0] == 'g')
                        {
                            D();
                            D();
                            FourSpinMethod('f');
                        }
                        else if (b[2, 0][0] == 'r')
                        {
                            ReverseD();
                            FourSpinMethod('r');
                        }
                        else if (b[2, 0][0] == 'b')
                        {
                            FourSpinMethod('b');
                        }
                        else
                        {
                            D();
                            FourSpinMethod('l');
                        }
                    }
                    else
                    {
                        if (l[2, 0][0] == 'g')
                        {
                            D();
                            FourSpinMethod('f');
                        }
                        else if (l[2, 0][0] == 'r')
                        {
                            D();
                            D();
                            FourSpinMethod('r');
                        }
                        else if (l[2, 0][0] == 'b')
                        {
                            ReverseD();
                            FourSpinMethod('b');
                        }
                        else
                        {
                            FourSpinMethod('l');
                        }
                    }
                }
            }

        }
        private bool FindConditionToBasicPll()
        {
            if (f[2, 0][0] == f[2, 2][0] && f[2, 0][0] == f[1, 1][0] && r[2, 0][0] == r[2, 2][0] && r[2, 0][0] == r[1, 1][0]
                && b[2, 0][0] == b[2, 2][0] && b[2, 0][0] == b[1, 1][0] && l[2, 0][0] == l[2, 2][0] && l[2, 0][0] == l[1, 1][0])
            {
                return true;
            }

            return false;
        }
        private void CorrrectThirdFloor()
        {
            //U a perm
            if (l[2, 1][0] == l[1, 1][0] && f[2, 1][0] == b[1, 1][0] && b[2, 1][0] == r[1, 1][0] && r[2, 1][0] == f[1, 1][0])
            {
                F();
                ReverseD();
                F();
                D();
                F();
                D();
                F();
                ReverseD();
                ReverseF();
                ReverseD();
                F();
                F();
            }
            else if (f[2, 1][0] == f[1, 1][0] && r[2, 1][0] == l[1, 1][0] && l[2, 1][0] == b[1, 1][0] && b[2, 1][0] == r[1, 1][0])
            {
                R();
                ReverseD();
                R();
                D();
                R();
                D();
                R();
                ReverseD();
                ReverseR();
                ReverseD();
                R();
                R();
            }
            else if (r[2, 1][0] == r[1, 1][0] && b[2, 1][0] == f[1, 1][0] && f[2, 1][0] == l[1, 1][0] && l[2, 1][0] == b[1, 1][0])
            {
                B();
                ReverseD();
                B();
                D();
                B();
                D();
                B();
                ReverseD();
                ReverseB();
                ReverseD();
                B();
                B();
            }
            else if (b[2, 1][0] == b[1, 1][0] && l[2, 1][0] == r[1, 1][0] && r[2, 1][0] == f[1, 1][0] && f[2, 1][0] == l[1, 1][0])
            {
                L();
                ReverseD();
                L();
                D();
                L();
                D();
                L();
                ReverseD();
                ReverseL();
                ReverseD();
                L();
                L();
            }
            //Ub perm
            if (l[2, 1][0] == l[1, 1][0] && b[2, 1][0] == f[1, 1][0] && f[2, 1][0] == r[1, 1][0] && r[2, 1][0] == b[1, 1][0])
            {
                F();
                F();
                D();
                F();
                D();
                ReverseF();
                ReverseD();
                ReverseF();
                ReverseD();
                ReverseF();
                D();
                ReverseF();
            }
            else if (f[2, 1][0] == f[1, 1][0] && l[2, 1][0] == r[1, 1][0] && r[2, 1][0] == b[1, 1][0] && b[2, 1][0] == l[1, 1][0])
            {
                R();
                R();
                D();
                R();
                D();
                ReverseR();
                ReverseD();
                ReverseR();
                ReverseD();
                ReverseR();
                D();
                ReverseR();
            }
            else if (r[2, 1][0] == r[1, 1][0] && f[2, 1][0] == b[1, 1][0] && b[2, 1][0] == l[1, 1][0] && l[2, 1][0] == f[1, 1][0])
            {
                B();
                B();
                D();
                B();
                D();
                ReverseB();
                ReverseD();
                ReverseB();
                ReverseD();
                ReverseB();
                D();
                ReverseB();
            }
            else if (b[2, 1][0] == b[1, 1][0] && r[2, 1][0] == l[1, 1][0] && l[2, 1][0] == f[1, 1][0] && f[2, 1][0] == r[1, 1][0])
            {
                L();
                L();
                D();
                L();
                D();
                ReverseL();
                ReverseD();
                ReverseL();
                ReverseD();
                ReverseL();
                D();
                ReverseL();
            }
            //Z perm
            // B->L && R->F
            if (b[2, 1][0] == l[1, 1][0] && l[2, 1][0] == b[1, 1][0] && f[2, 1][0] == r[1, 1][0] && r[2, 1][0] == f[1, 1][0])
            {
                MX();
                MX();
                D();
                MX();
                MX();
                D();
                ReverseMX();
                D();
                D();
                MX();
                MX();
                D();
                D();
                ReverseMX();
                D();
                D();
            }
            //R->B && F->L
            else if (l[2, 1][0] == f[1, 1][0] && f[2, 1][0] == l[1, 1][0] && r[2, 1][0] == b[1, 1][0] && b[2, 1][0] == r[1, 1][0])
            {
                M();
                M();
                D();
                M();
                M();
                D();
                ReverseM();
                D();
                D();
                M();
                M();
                D();
                D();
                ReverseM();
                D();
                D();
            }
            //H perm
            //B->F && L->R
            else
            {
                M();
                M();
                D();
                M();
                M();
                D();
                D();
                M();
                M();
                D();
                M();
                M();
            }
        }
        private bool FindDCondition()
        {
            if (d[0, 0][0] == 'y' && d[0, 1][0] == 'y' && d[0, 2][0] == 'y' && d[1, 0][0] == 'y' && d[1, 1][0] == 'y' && d[1, 2][0] == 'y' && d[2, 0][0] == 'y' && d[2, 1][0] == 'y' && d[2, 2][0] == 'y')
            {
                return true;
            }

            return false;
        }
        private void SolveThirdFloor()
        {
            while (!(d[0, 1][0] == 'y' && d[1, 0][0] == 'y' && d[2, 1][0] == 'y' && d[1, 2][0] == 'y'))
            {
                MakeYellowCross();
            }

            while (!FindDCondition())
            {
                CompleteDSide();
            }
            MakeFinalCondition();
            MakeFinalCondition();
            while (!FindConditionToBasicPll())
            {
                D();
            }

            while (!(f[2, 1][0] == f[1, 1][0] && r[2, 1][0] == r[1, 1][0] && b[2, 1][0] == b[1, 1][0] && l[2, 1][0] == l[1, 1][0]))
            {
                CorrrectThirdFloor();
            }
        }
        //
        public void Solve()
        {
            SolveFirstFloor();
            SolveSecondFloor();
            SolveThirdFloor();
        }
    }

    public class RubikSolveMachine
    {
        public RubikSolveMachine()
        {
            Rubik a = new Rubik();
            string input = @"E:\Education\Ngoai le\Rubik Solving Machine\ConsoleApp1\Input.txt";
            string output = @"E:\Education\Ngoai le\Rubik Solving Machine\ConsoleApp1\Output.txt";
            string outputF = @"E:\Education\Ngoai le\Rubik Solving Machine\ConsoleApp1\OutputA.txt";

            DateTime start, end;
            a.Read(input);
            start=DateTime.Now;
            a.Solve();
            end=DateTime.Now;
            a.Print(output);
            a.PrintAlgorithm(outputF);
            Console.WriteLine("Runtime: {0:g}",end-start);
        }
    }

}