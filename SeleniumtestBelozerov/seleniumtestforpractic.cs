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

    [Test] // Проверяем создание сообщества
    public void CommunityСreation() 
    {
        //Авторизация
        Autorization();
        //создание сообщества (вынес код, т.к. еще в удалении будут те же строки)
        HostCommunity();
        
        
        var Ypravleniesoobshestvom = driver.FindElement(By.CssSelector("[data-tid='Title']"));
        Ypravleniesoobshestvom.Should().NotBeNull(); // проверяем, что сообщество создалось и мы попали в упарвление сообществом.

    }
    [Test] //Проверяем удаление сообщества
    public void CommunityDelete() 
    {
        //Авторизация
        Autorization();
        //создание сообщества
        HostCommunity();
        var DeleteButton = driver.FindElement(By.CssSelector("[data-tid='DeleteButton']"));
        DeleteButton.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var KnopkaYdalit  = driver.FindElement(By.CssSelector(".react-ui-button-caption"));
        KnopkaYdalit.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        //тут должно быть что-то проверяющее удаление сообщества? Пока не придумал, буду думать :с
    }

    [Test] // Проверяем создание обсуждения
    public void CreateDiscussion() 
    
    {
//Авторизация
        Autorization();
//создание сообщества
        HostCommunity();
        //создание обсуждения
        CreateaDiscussion();
        
        var ProverkaSozdaniyaSoobshestva   = driver.FindElement(By.CssSelector("[data-tid='Link']"));
        ProverkaSozdaniyaSoobshestva.Should().NotBeNull(); //проверяем, что обсуждение создалось
    }

    [Test] //Проверяем удаление обсуждения
    public void DeleteDiscussion() 
    {
        //Авторизация
        Autorization();
//создание сообщества
        HostCommunity();
        //создание обсуждения
        CreateaDiscussion();
        var Discussion   = driver.FindElement(By.CssSelector("[data-tid='Link']"));
        Discussion.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var Menu   = driver.FindElement(By.XPath("//*[@id=\"root\"]/section/section[2]/div/div/div/section/div[2]/div[2]/div/div/div/span/button"));
        Menu.Click();
        Thread.Sleep(5000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания 
        var DeleteRecord = driver.FindElement(By.CssSelector("[data-tid='DeleteRecord']"));
        DeleteRecord.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var DeleteButton = driver.FindElement(By.CssSelector("[data-tid='DeleteButton']"));
        DeleteButton.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var NoDiscussion = driver.FindElement(By.XPath("//*[@id=\"root\"]/section/section[2]/div/div/div/section/div/div/div"));
        NoDiscussion.Should().NotBeNull(); //проверяем, что дискуссий нет
    }

    public void CreateaDiscussion()
    {
        var closed = driver.FindElement(By.XPath("//*[@id=\"root\"]/section/section[2]/section/div/button"));
        closed.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var Discussions =
            driver.FindElement(By.XPath("//*[@id=\"root\"]/section/section[2]/div/div/section/div[2]/div[1]/a[2]"));
        Discussions.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var HostDiscussion =
            driver.FindElement(
                By.XPath("//*[@id=\"root\"]/section/section[2]/div/div/div/section/span/button/div[2]/span[2]"));
        HostDiscussion.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var NameDiscussion = driver.FindElement(By.CssSelector("[data-tid='Name']"));
        NameDiscussion.SendKeys("Название обсуждения");
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var MesageDiscussion = driver.FindElement(By.CssSelector(".public-DraftEditor-content"));
        MesageDiscussion.SendKeys("Сообщение обсуждения");
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
        var CreateButton = driver.FindElement(By.CssSelector("[data-tid='CreateButton']"));
        CreateButton.Click();
        Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
    }

    public void HostCommunity()
{
    var communities = driver.FindElement(By.CssSelector("[data-tid='Community']"));
    communities.Click();
    Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
    var Creation  = driver.FindElement(By.XPath("/html/body/div/section/section[2]/section/div[2]/span/button"));
    Creation.Click();
    Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
    var NameCommunites  = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/div/div/div[3]/div[2]/div/span/div/div[2]/div[1]/span/label/div/div/textarea"));
    NameCommunites.SendKeys("Название сообщества");
    Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
    var CreationButter  = driver.FindElement(By.CssSelector(".react-ui-m0adju"));
    CreationButter.Click();
    Thread.Sleep(3000); //понимаю,что сильные и независимые пограмисты их не используют, буду менять на другие ожидания
    
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