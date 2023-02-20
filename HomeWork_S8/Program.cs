/* 1. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
Пример: Есть набор данных
{ 1, 9, 9, 0, 2, 8, 0, 9 }
частотный массив может быть представлен так:
0 встречается 2 раза
1 встречается 1 раз
2 встречается 1 раз
8 встречается 1 раз
9 встречается 3 раза

Если набор данных - таблица
1, 2, 3
4, 6, 1
2, 1, 6
на выходе ожидаем получить
1 встречается 3 раза
2 встречается 2 раз
3 встречается 1 раз
4 встречается 1 раз
6 встречается 2 раза

Пример частотного массива для текстовых данных: Входные данные:
Частотный анализ – это один из методов криптоанализа, основывающийся на предположении о существовании нетривиального статистического распределения 
отдельных символов и их последовательностей как в открытом тексте, так и шифрованном тексте, которое с точностью до замены символов будет сохраняться в процессе шифрования и дешифрования.
Частотный анализ может выглядеть так

Символ пробел/space встречается 41 раз. Частота 12.28%
Символ о встречается 38 раз. Частота 11.38%

2. Найти произведение двух матриц
3. В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
4. Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента
5. Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника
*/
internal class Program
{
  private static void Main(string[] args)
  {
    int Proverca_chisla(string text)
    {
      Console.Write(text);
      int num;
      while (true)
        if (int.TryParse(Console.ReadLine(), out num))
          return num;                                                   // обработка при успехе и выход из цикла
        else                                                         // обработка при ошибке
        {
          Console.WriteLine("[ERROR]: Некоректные данные по пробуйте еще раз!");
          Console.Write("Введите число: ");
        }
    }

    //Создание одномерного массива с случайными числами
    int[] CreateMass1d(int n, int min, int max)
    {
      int[] arra = new int[n];
      for (int i = 0; i < arra.Length; i++)
        arra[i] = new Random().Next(min, max);
      return arra;
    }
    //Создание двухмерного массива с случайными числами
    int[,] CreateMass2d(int strok, int stolbtsov, int min, int max)
    {
      int[,] arra = new int[stolbtsov, strok];
      for (int i = 0; i < arra.GetLength(0); i++)
        for (int j = 0; j < arra.GetLength(1); j++)
          arra[i, j] = new Random().Next(min, max);
      return arra;
    }

    //Создание трехмерного массива с случайными числами
    int[,,] CreateMass3d(int strok, int stolbtsov, int glubina, int min, int max,bool type) // если Bool переменная равна true то переменные в цикле не повторяются
    { int[,,] arra = new int[glubina,stolbtsov, strok];
      for (int i = 0; i < arra.GetLength(0); i++)
        for (int j = 0; j < arra.GetLength(1); j++)
          for (int l = 0; l < arra.GetLength(2); l++)
           if (type)
            { bool con=false,sikl=false;
              do
              { con=false;sikl=false;
                arra[i, j, l] = new Random().Next(min, max);
                for (int p1 = 0; p1 < arra.GetLength(0); p1++)
                  {
                  for (int p2 = 0; p2 < arra.GetLength(1); p2++)
                    {
                    for (int p3 = 0; p3 < arra.GetLength(2); p3++)
                      if (i!=p1 || j!=p2 || l!=p3)
                      if (arra[i,j,l]==arra[p1,p2,p3]) {con=true;sikl=true;break;}
                    if (sikl)break;
                    }
                  if (sikl)break;
                  }  
              } while(con);
            }         
           else
            arra[i, j, l] = new Random().Next(min, max);                  
      return arra;
    }

    //Печать одномерного массива
    void PrintMass1d(int[] arra)
    {
      for (int i = 0; i < arra.GetLength(0); i++)
        Console.Write($"{arra[i]} ");
      Console.WriteLine();
    }
    //Печать двухмерного массива
    void PrintMass2d(int[,] arra)
    {
      for (int i = 0; i < arra.GetLength(0); i++)
      {
        for (int j = 0; j < arra.GetLength(1); j++)
          Console.Write($"{arra[i, j]} ");
        Console.WriteLine();
      }
    }
    //Печать двухмерного массива
    void PrintMass3d(int[,,] arra)
    {
      for (int i = 0; i < arra.GetLength(0); i++)
      {
        for (int j = 0; j < arra.GetLength(1); j++)
          {
          for (int l = 0; l < arra.GetLength(2); l++)
            System.Console.Write($"{arra[i, j, l]} ");
          System.Console.WriteLine();
          }
        System.Console.WriteLine();
      }
    }
    //Печать цифр заданных значений
    void Print_int(int[] count, int min, int max, double percent)
    {
      for (int i = min; i < max; i++)
        if (count[i] != 0) { Console.WriteLine($"{i} встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); }
    }
    //Печать символов
    void Print_String(int[] count, double percent)
    {
      Print_int(count, 0, 10, percent);

      for (int i = 0; i < count.Length; i++)
        if (count[i] != 0)
        {
          switch (i)
          {
            case 10: Console.WriteLine($"' ' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 11: Console.WriteLine($"'q' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 12: Console.WriteLine($"'w' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 13: Console.WriteLine($"'e' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 14: Console.WriteLine($"'r' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 15: Console.WriteLine($"'t' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 16: Console.WriteLine($"'y' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 17: Console.WriteLine($"'u' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 18: Console.WriteLine($"'i' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 19: Console.WriteLine($"'o' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 20: Console.WriteLine($"'p' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 21: Console.WriteLine($"'a' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 22: Console.WriteLine($"'s' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 23: Console.WriteLine($"'d' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 24: Console.WriteLine($"'f' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 25: Console.WriteLine($"'g' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 26: Console.WriteLine($"'h' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 27: Console.WriteLine($"'j' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 28: Console.WriteLine($"'k' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 29: Console.WriteLine($"'l' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 30: Console.WriteLine($"'z' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 31: Console.WriteLine($"'x' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 32: Console.WriteLine($"'c' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 33: Console.WriteLine($"'v' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 34: Console.WriteLine($"'b' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 35: Console.WriteLine($"'n' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 36: Console.WriteLine($"'m' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 37: Console.WriteLine($"',' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 38: Console.WriteLine($"'.' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 39: Console.WriteLine($"'-' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 40: Console.WriteLine($"'=' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 41: Console.WriteLine($"'+' встречается {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
            case 42: Console.WriteLine($"Другие символы встречаются {count[i]} раз. Частота {(count[i]/percent)*100} %"); break;
          }
        }
    }

    //Поиск заданных чисел в одномерном массиве
    int[] SerchItem_1dMass(int[] arra, int min, int max)
    {
      int[] count = new int[max - min + 2];
      for (int i = 0; i < arra.Length; i++)
        for (int j = min; j < max + 1; j++)
          if (arra[i] == j) { count[j]++; break; }
      return count;
    }
    //Поиск заданных чисел в двухмерном массиве
    int[] SerchItem_2dMass(int[,] arra, int min, int max)
    {
      int[] count = new int[max - min + 2];
      for (int i = 0; i < arra.GetLength(0); i++)
        for (int j = 0; j < arra.GetLength(1); j++)
          for (int k = min; k < max + 1; k++)
            if (arra[i, j] == k) { count[k]++; break; }
      return count;
    }
    //Поиск количестов символов в строке
    int[] SerchItem_String(string? a)
    {
      int[] count = new int[42];
      for (int i = 0; i < a?.Length; i++)
        switch (a[i])
        {
          case '0': count[0]++; break;
          case '1': count[1]++; break;
          case '2': count[2]++; break;
          case '3': count[3]++; break;
          case '4': count[4]++; break;
          case '5': count[5]++; break;
          case '6': count[6]++; break;
          case '7': count[7]++; break;
          case '8': count[8]++; break;
          case '9': count[9]++; break;
          case ' ': count[10]++; break;
          case 'q': count[11]++; break;
          case 'w': count[12]++; break;
          case 'e': count[13]++; break;
          case 'r': count[14]++; break;
          case 't': count[15]++; break;
          case 'y': count[16]++; break;
          case 'u': count[17]++; break;
          case 'i': count[18]++; break;
          case 'o': count[19]++; break;
          case 'p': count[20]++; break;
          case 'a': count[21]++; break;
          case 's': count[22]++; break;
          case 'd': count[23]++; break;
          case 'f': count[24]++; break;
          case 'g': count[25]++; break;
          case 'h': count[26]++; break;
          case 'j': count[27]++; break;
          case 'k': count[28]++; break;
          case 'l': count[29]++; break;
          case 'z': count[30]++; break;
          case 'x': count[31]++; break;
          case 'c': count[32]++; break;
          case 'v': count[33]++; break;
          case 'b': count[34]++; break;
          case 'n': count[35]++; break;
          case 'm': count[36]++; break;
          case ',': count[37]++; break;
          case '.': count[38]++; break;
          case '-': count[39]++; break;
          case '=': count[40]++; break;
          case '+': count[41]++; break;
          default: count[42]++; break; //другие символы
        }
      return count;
    }

    //Умножения матри А на B
    int[,] Multiplication_matrix(int[,] A, int [,] B)
    {
      int[,] C = new int [A.GetLength(0),B.GetLength(1)];
      for (int i = 0; i < A.GetLength(0); i++)
        for (int j = 0; j < B.GetLength(1); j++)
          for(int l = 0; l < A.GetLength(1);l++)
            C[i,j] += A[i,l] * B[l,j]; 
      return C;
    }

    //Нахождения меньшего числа в матрице
    (int,int) MinItemPosition (int [,] arra)
    {
      int min = arra[0,0];
      int position1=0, position2=0;
      for (int i = 0; i < arra.GetLength(0); i++)
        for (int j = 0; j < arra.GetLength(1); j++)
          if (arra[i,j] < min) {min = arra[i,j]; position1 = i; position2 = j;}       
      return (position1,position2);
    }

    //Удаление строки
    int[,] DelStrok(int [,]arra, int strok)
    { 
      int x=0;
      int[,] temp = new int[arra.GetLength(0)-1, arra.GetLength(1)];
      for (int i = 0; i < arra.GetLength(0); i++)
        if (i !=strok) 
        {
        for (int j = 0; j < arra.GetLength(1); j++)
          temp[x,j] = arra[i,j];
        x++;
        }
      return temp;
    }
    //удаления столбца
    int[,] DelStolbets(int [,]arra, int Stolbets)
    { 
      int[,] temp = new int[arra.GetLength(0), arra.GetLength(1)-1];
      for (int i = 0; i < arra.GetLength(0); i++)
        {
        int x=0;
        for (int j = 0; j < arra.GetLength(1); j++)
        if (j !=Stolbets) 
        { temp[i,x] = arra[i,j]; x++;}
        }      
      return temp;
    }

    int otvet1 = 0;
    string? otvet2;
    do
    {
      do
      {
        Console.Clear();

        Console.WriteLine("Добрый день прошу выбрать цифру из списка что Вы хотите сделать?");
        Console.WriteLine("__________");
        Console.WriteLine("1. Частотный словарь.");
        Console.WriteLine("2. Найти произведение двух матриц.");
        Console.WriteLine("3. В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.");
        Console.WriteLine("4. Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента.");
        Console.WriteLine("5. Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника.");
        Console.WriteLine(" ");
        otvet1 = Proverca_chisla("Ваш ответ: ");

        if (otvet1 > 5 ^ otvet1 < 1)
        {
          Console.WriteLine("Такой задачи тут нету!");
          Console.Write("Нажмите <Enter> для повторго ввода... ");
          while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

      } while (otvet1 > 5 ^ otvet1 < 1);

      Console.Clear();

      //Начало тела задач
      
      //1. Частотный словарь.
      if (otvet1 == 1)
      {
        int o1 = 0;
        do
        {
          Console.WriteLine("Введите какой массив выхотите:");
          Console.WriteLine("1. Одномерный.");
          Console.WriteLine("2. Двухмерный.");
          Console.WriteLine("3. Символы.");
          o1 = Proverca_chisla("Ваш ответ: ");
          if (o1 > 3 ^ otvet1 < 1)
          {
            Console.WriteLine("Такой задачи тут нету!");
            Console.Write("Нажмите <Enter> для повторго ввода... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
          }

        } while (o1 > 3 ^ otvet1 < 1);
        Console.Clear();

        if (o1 == 1)
        { //решение для одномерного массива
          int n1 = Proverca_chisla("Введите длину массива: ");
          int min1 = Proverca_chisla("Введите минимальное значения массива: ");
          int max1 = Proverca_chisla("Введите максимальное значения массива: ");
          int[] arra1 = CreateMass1d(n1, min1, max1);
          PrintMass1d(arra1);

          //Console.WriteLine($"0 встречается {arra1.Count(element => element == 1)} раза");
          int[] count = SerchItem_1dMass(arra1, min1, max1);
          //PrintMass1d(count);
          Print_int(count, min1, max1, arra1.Length);
        }
        else
        {
          if (o1 == 2)
          {
            int n1 = Proverca_chisla("Введите количетсво строк двухмерного массива: ");
            int m1 = Proverca_chisla("Введите количетсво столбцов двухмерного массива: ");
            int min1 = Proverca_chisla("Введите минимальное значения массива: ");
            int max1 = Proverca_chisla("Введите максимальное значения массива: ");
            int[,] arra1 = CreateMass2d(n1, m1, min1, max1);
            PrintMass2d(arra1);

            int[] count = SerchItem_2dMass(arra1, min1, max1);

            Print_int(count, min1, max1, arra1.Length);
          }
          else
          {
            Console.WriteLine("Введите текст для анализа: ");
            string? a = Console.ReadLine();

            int[] count = SerchItem_String(a);

            int percent = 0;
            if (a?.Length != null) percent = a.Length;
            Print_String(count, percent);
          }
        }
      }

      //2. Найти произведение двух матриц.
      if (otvet1 == 2)
      {
        int n2 = Proverca_chisla("Введите количетсво строк первой двухмерной матрицы: ");
        int m2 = Proverca_chisla("Введите количетсво столбцов первой двухмерной матрицы: ");
        int c2 = Proverca_chisla("Введите количетсво строк вторую двухмерной матрицы: ");
        int s2 = Proverca_chisla("Введите количетсво столбцов вторую двухмерной матрицы: ");
        int min2 = Proverca_chisla("Введите минимальное значения рандома матрицы: ");
        int max2 = Proverca_chisla("Введите максимальное значения рандома матрицы: ");
        int[,] matrixA = CreateMass2d(n2, m2, min2, max2);
        int[,] matrixB = CreateMass2d(c2, s2, min2, max2);
        
        System.Console.WriteLine("Матрица А: ");
        PrintMass2d(matrixA);
        System.Console.WriteLine("Матрица B: ");
        PrintMass2d(matrixB);

        if(matrixA.GetLength(1) == matrixB.GetLength(0))
          {
          int[,] matrixC = Multiplication_matrix(matrixA,matrixB);
          System.Console.WriteLine("Матрица поcле перемножения: ");
          PrintMass2d(matrixC);
          }
        else
          System.Console.WriteLine("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");      
      }
      
      //3. В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
      if (otvet1 == 3)
      {        
        int n3 = Proverca_chisla("Введите количетсво строк двухмерного массива: ");
        int m3 = Proverca_chisla("Введите количетсво столбцов двухмерного массива: ");
        int min3 = Proverca_chisla("Введите минимальное значения массива: ");
        int max3 = Proverca_chisla("Введите максимальное значения массива: ");
        int[,] arra3 = CreateMass2d(n3, m3, min3, max3);
        System.Console.WriteLine("Получилась следующая матрица: ");
        PrintMass2d(arra3);

        (int position1, int position2)  = MinItemPosition(arra3);
        arra3 = DelStrok(arra3,position1);
        arra3 = DelStolbets(arra3,position2);
        
        System.Console.WriteLine("");
        System.Console.WriteLine("Получилась следующая матрица после удаления строки и столбца на пересечении: ");
        PrintMass2d(arra3);
      }

      //4. Сформировать трехмерный массив не повторяющимися двузначными числами показать его построчно на экран выводя индексы соответствующего элемента.
      if (otvet1 == 4)
      {        
        int n4 = Proverca_chisla("Введите ширину трехмерного массива: ");
        int m4 = Proverca_chisla("Введите высоту трехмерного массива: ");
        int l4 = Proverca_chisla("Введите глубину трехмерного массива: ");
        //int min4 = Proverca_chisla("Введите минимальное значения массива: ");
        //int max4 = Proverca_chisla("Введите максимальное значения массива: ");
        int[,,] arra4 = CreateMass3d(n4, m4, l4, 10, 99, true);
        System.Console.WriteLine("Получилась следующая матрица: ");
        PrintMass3d(arra4);
      }

      //Конец тела задач    
      System.Console.Write("Нажмите <Enter> для продолжения... ");
      while (Console.ReadKey().Key != ConsoleKey.Enter) { }

      do
      {
        Console.Clear();
        Console.WriteLine("Вы хотите воспользоваться еще одним решением? Yes/No");
        Console.WriteLine(" ");
        otvet2 = Console.ReadLine();

        if (otvet2 != "No" && otvet2 != "no" && otvet2 != "NO" && otvet2 != "n" && otvet2 != "N"
            && otvet2 != "Yes" && otvet2 != "yes" && otvet2 != "YES" && otvet2 != "y" && otvet2 != "Y")
        {
          Console.WriteLine("Некоректный ответ");
          Console.Write(" Нажмите <Enter> для повторго ввода... ");
          while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
      }
      while (otvet2 != "No" && otvet2 != "no" & otvet2 != "NO" && otvet2 != "n" && otvet2 != "N"
            && otvet2 != "Yes" && otvet2 != "yes" && otvet2 != "YES" && otvet2 != "y" && otvet2 != "Y");

    }
    while (otvet2 != "No" & otvet2 != "no" & otvet2 != "NO" & otvet2 != "n" & otvet2 != "N");

    Console.Clear();

    Console.WriteLine("Спасибо, что воспользовались программой. Досвидание!!!");
    Console.Write("Нажмите <Enter> для выхода... ");
    while (Console.ReadKey().Key != ConsoleKey.Enter) { }

    Console.Clear();
  }
}