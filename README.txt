Тестовое задание для СБК "Контур"

-------------------------------------------------------------------------------

Есть два файла:
1. Файл, в котором перечислены имена детей. Все имена различны.
2. Файл, в котором перечислено, кто кому из детей симпатичен.
Симпатия - это однонаправленное чувство.  То есть если Петя симпатичен Кате, 
то Катя может быть совсем не симпатична Пете.
Одному ребенку могут быть симпатичны несколько других детей. Ребенок не может 
быть симпатичен сам себе. 
 
Задача:
1. Разработать формат указанных выше файлов.
2. Разработать программу, которая принимает на вход два указанных выше файла и 
   по требованию выдает один из следующих списков:
  · список всех не любимчиков, то есть детей которые никому не симпатичны
  · список всех несчастных детей, то есть тех, которые не симпатичны ни одному 
    ребенку из тех, кто симпатичен им самим. За исключением тех детей, которым 
	никто не симпатичен.
  · список любимчиков, то есть всех детей, которые симпатичны максимальному 
    количеству других детей.
3. Описать положительные и отрицательные стороны  предложенного решения.

-------------------------------------------------------------------------------

Запускаемый проект: "Kontur.TestTask.Console"
Аргументы командной строки: "Имя файла с детьми" "Имя файла с симпатиями"

Чтобы не изобретать велосипед, в качестве формата хранения используется 
обычный xml файл, тем более .NET Framework уже имеет средства для работы с xml
В любом случае, все знания о конкретном формате файла скрыты за интерфейсами

Тесты покрывают только положительные сценарии работы, то есть null значения,
пустые списки, исключения и т.п. не тестировались (т.к. тестовое задание)

Можно спроектировать иерархию исключений (DuplicateChildNameException и т.п.)
вместо кидания базового Exception с сообщением при ошибках,
добавить больше защитного программирования, проверок на некорректные значения 
параметров.
