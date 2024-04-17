using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal.Logging;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ForGitExtensions;

public class SeleniumTestsForPractice
{

    public ChromeDriver driver;

    [Test]
    public void Authorization()
    {
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--start-maximized", "--disable-extensions");

// - зайти в хром ( с помощью вебдрайвера)
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // неявное ожидание


// - перейти по урлу https://staff-testing.testkontur.ru

        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru");

//Ожидание появления страницы и отрисовки элементов в верстке

//Thread.Sleep(3000); - плохой вариант

// var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3)); - явное ожидание
// wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Username")));

// - ввести логин и пароль
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys("a.belozerov@skbkontur.ru");

        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("xPtqNJbcomETL7sSDnaCRMKr@");

// - нажать на кнопку "войти"
        var enter = driver.FindElement(By.Name("button"));
        enter.Click();
                Thread.Sleep(3000);

// ожидание
//Thread.Sleep(3000); //плохой вариант

// - проверяем что мы находимся на нужной странице
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/news");


                //Assert.That(currentUrl == "https://staff-testing.testkontur.ru/news","current url = " + currentUrl + " а должен быть https://staff-testing.testkontur.ru/news");

//currentUrl.Should().Be("https://staff-testing.testkontur.ru/news");

// закрываем браузер и убиваем процесс драйвера

    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}