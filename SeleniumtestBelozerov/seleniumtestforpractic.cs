using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumtestBelozerov;

public class seleniumtestforpractic
{
    [Test]
    public void authorization()
    {
        // 231456

// зайти в хром  (с помощью вебдрайвера)
        var driver = new ChromeDriver();

// перейти по урлу https://staff-testing.testkontur.ru
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru");
        Thread.Sleep(millisecondsTimeout:5000);

// ввести логин и пароль
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys(text:"a.belozerov@skbkontur.ru");
        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("xPtqNJbcomETL7sSDnaCRMKr@"); 
        Thread.Sleep(millisecondsTimeout:5000);  
// нажать на кнопку "войти"
        var Enter = driver.FindElement(By.Name("button")); 
        Enter.Click();
        Thread.Sleep(millisecondsTimeout:5000);  

// 7

// проверяем что мы находимся на нужной странице 
        var currentURL = driver.Url;
        Assert.That( currentURL == "https://staff-testing.testkontur.ru/news");
// закрываем браузер и убиваем процесс драйвера
        driver.Quit();
    }
}                              