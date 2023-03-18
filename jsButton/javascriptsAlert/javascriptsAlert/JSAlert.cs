namespace javascriptsAlert;

public class JSAlert
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void TestJSAlert()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var alertButton = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
        alertButton.Click();

        var alertPopup = driver.SwitchTo().Alert();
        Assert.IsTrue(alertPopup.Text.Contains("I am a JS Alert"));

        alertPopup.Accept();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You successfully clicked an alert"));
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }

}
