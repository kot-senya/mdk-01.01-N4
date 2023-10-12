# Практическая работа 4. Основы wpf

### Данная программа реализует следующий функционал:
- [X] по введенной дате, пользователь узнает сколько лет, месяцев и дней прошло с момента дня рождения
- [X] пользователь получает информацию о том в какой день родился и количество раз, когда выбранная дата рождения попадала на этот день недели
- [X] пользователь получает информацию о том, сколько високосных лет прошло с момента его рождения, и перечень данных лет
- [X] пользователь может узнать свой задиак выбрав тип календаря
  +  *восточный*
  +  *славянский*

<p align="center">
  <img width="502" height="417" src="https://github.com/kot-senya/mdk-01.01-N4/blob/master/image.png">
</p>

---

### Реализация программы

Выбранная пользователем дата, полученная с помощью `myDatePicker.SelectedDate.Value`, имеет следущую проверку:
```c#
DateTime date = DP.SelectedDate.Value;

if (date > DateTime.Now)
{
  //somethig code
  MessageBox.Show("Выбранная дата не может быть больше текущей");
}
else
{
  //somethig code
}
```

---
### Автор
* *GitHub* - [kot-senya](https://github.com/kot-senya)
