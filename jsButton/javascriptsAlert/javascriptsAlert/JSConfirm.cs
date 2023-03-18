namespace javascriptsAlert;

public class JSConfirm
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void ConfirmPopup()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var confirmButton = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        confirmButton.Click();

        var confirmPopup = driver.SwitchTo().Alert();
        Assert.IsTrue(confirmPopup.Text.Contains("I am a JS Confirm"));
    }

    [Test, Order(2)]
    public void ConfirmAccept()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var confirmButton = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        confirmButton.Click();

        var confirmPopup = driver.SwitchTo().Alert();
        confirmPopup.Accept();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You clicked: Ok"));
    }

    [Test, Order(3)]
    public void ConfirmDismiss()
    {
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, 0));

        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='example']/h3[text()='JavaScript Alerts']")));

        var confirmButton = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        confirmButton.Click();

        var confirmPopup = driver.SwitchTo().Alert();
        confirmPopup.Dismiss();
        var resultLabel = driver.FindElement(By.Id("result"));
        Assert.IsTrue(resultLabel.Text.Contains("You clicked: Cancel"));
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }

}
