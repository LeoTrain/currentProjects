namespace MenuBuilder
{
  public class MenuOption
  {
    public string Label { get; }
    public Action Action { get; }

    public MenuOption(string label, Action action)
    {
      Label = label;
      Action = action;
    }

    public void Execute()
    {
      Action.Invoke();
    }
  }
}
