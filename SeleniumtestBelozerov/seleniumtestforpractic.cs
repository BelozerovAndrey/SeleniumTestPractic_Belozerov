using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace Seleniumtestforpractic;

public class SeleniumTestsForPractic
{

    public ChromeDriver driver;

    [Test] //проверяем авторизацию
    public void Authorization()
    {
        Autorization();
        var news = driver.FindElement(By.CssSelector("[data-tid='Title']")); 
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/news");
    }

    [Test]
    public void CommunityСreation() //создание сообщества
    {
        //Авторизация
        Autorization();
        var communities = driver.FindElement(By.CssSelector("[data-tid='Community']"));
        communities.Click();
        Thread.Sleep(3000);
        var Creation  = driver.FindElement(By.XPath("/html/body/div/section/section[2]/section/div[2]/span/button"));
        Creation.Click();
        Thread.Sleep(3000);
        var NameCommunites  = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div/div/div[3]/div[2]/div/span/div/div[2]/div[1]/span/label/div/div/textarea"));
        NameCommunites.SendKeys("Тестирую создание сообщества");
        Thread.Sleep(3000);
    }

    public void Autorization()
    {
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--start-maximized", "--disable-extensions");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru");
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys("a.belozerov@skbkontur.ru");
        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("xPtqNJbcomETL7sSDnaCRMKr@");
        var enter = driver.FindElement(By.Name("button"));
        enter.Click();
        }
[TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}