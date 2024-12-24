int ft_fibonacci(int index)
{
  if (index < 0)
    return -1;
  int a = 0;
  int b = 1;
  int next = a + b;
  for (int i = 0; i < index; i++)
  {
    next = a + b;
    a = b;
    b = next;
  }
  return a;
}
