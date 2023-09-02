using System.Collections;

namespace WinFormsApp1.CommonUtils;

public class BarGenerator
{

    private ProgressBar bar;
    private int stepValue;
    private int currentValue;
    private ICollection collection;

    public BarGenerator(ProgressBar bar, ICollection collection)
    {
        this.bar = bar;
        stepValue = currentValue / collection.Count;
        this.collection = collection;
    }

    public void setBarValue(int startValue)
    {
        bar.Value = startValue;
        currentValue = 100 - startValue;
        Thread.Sleep(100);
    }

    public void setBarCommonValue()
    {
        bar.Value = currentValue + stepValue;
        Thread.Sleep(100);
    }
}