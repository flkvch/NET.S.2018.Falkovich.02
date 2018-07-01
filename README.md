# Day 2

  * Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i<j). 
  Реализован [алгоритм InsertNumber](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArraysStringsAlgorithms/Algorithms.cs#L34) вставки битов с j-ого по i-ый бит одного числа в другое так, 
  чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево). 
  Разработаны модульные тесты ([NUnit](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArrayStringsAlgorithms.NUnitTests/AlgorithmTests.cs#L12) и [MS Unit Test](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArrayStringsAlgorithms.Tests/AlgorithmTests.cs#L10)) для тестирования метода.
  * Реализован метод [FilterDigit](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArraysStringsAlgorithms/Algorithms.cs#L61) который принимает массив целых чисел и фильтрует его таким образом, 
  чтобы на выходе остались только числа, содержащие заданную цифру (LINQ-запросы не использовать!) 
  Например, для цифры 7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 7, 70, 17}. 
  Разработаны модульные тесты [NUnit](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArrayStringsAlgorithms.NUnitTests/AlgorithmTests.cs#L35) и [MS](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/e6dd43bf53b680ea37849333ec3ff779fb9d477c/ArrayStringsAlgorithms.NUnitTests/AlgorithmTests.cs#L35) для тестирования метода.
