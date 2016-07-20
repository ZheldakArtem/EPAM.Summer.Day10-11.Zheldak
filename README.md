# EPAM.Summer.Day10-11.Zheldak


##Задание 1.
Реализовать метод для подсчета чисел последовательности Фибоначчи с использованием блок-итератора yield.

##Задание 2.
Разработать обобщенный класс-коллекцию Queue, реализующий основные операции для работы с очередью, а также предоставляющий возможность итерирования, реализовав итератор «вручную». Протестировать методы разработанного класса.

Задание 3. 
Разработать обобщенный класс-коллекцию Set, позволяющий работать только с переменными ссылочного типа и реализующий основные операции над множествами, а также предоставляющий возможность перечисления элементов коллекции. Протестировать методы разработанного класса.

Задание 4.
Разработать обобщенный класс BinarySearchTree, реализующий бинарное дерево поиска. Рассмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать разработанный класс BinaryTree, используя в качестве аргумента типа следующие типы:  int (использовать сравнение по умолчанию и подключаемый компаратор)  string (использовать сравнение по умолчанию и подключаемый компаратор)  пользовательский класс Book, реализующий интерфейс IComparable (использовать сравнение по умолчанию и подключаемый компаратор)  пользовательскую структуру Point, не реализующую интерфейс IComparable.

Задание 5.
Создать обобщенные классы для представления квадратной, симметрической и диагональной матриц (симметрическая матрица – это квадратная матрица, которая совпадает с транспонированной к ней; диагональная матрица – это квадратная матрица, у которой элементы вне главной диагонали заведомо имеют значения по умолчанию типа элемента). Описать в созданных классах событие, которое происходит при изменении элемента матрицы с индексами (i, j). Предусмотреть возможность расширения функциональности иерархии классов, добавив возможность для операции сложениядвух матриц любого вида.

Создать unit-тесты для тестирования методов разработанного типа.
