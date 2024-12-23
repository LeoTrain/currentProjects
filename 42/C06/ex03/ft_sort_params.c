#include <unistd.h>

void ft_putstr(char *str)
{
  int i = 0;
  while (str[i] != '\0')
  {
    write(1, &str[i], 1);
    i++;
  }
}

void ft_swap(char** a, char** b)
{
  char* temp = *a;
  *a = *b;
  *b = temp;
}

int ft_strcmp(char *s1, char *s2)
{
    int i = 0;
    while (!(s1[i] == '\0' && s2[i] == '\0'))
    {
        if (s1[i] - s2[i] != 0)
            return s1[i] - s2[i];
        i++;
    }
    return s1[i] - s2[i];
}

void ft_sort(int length, char** argv)
{
  for (int i = 1; i < length - 1; i++)
  {
    if (ft_strcmp(argv[i], argv[i + 1]) > 0)
    {
      ft_swap(&argv[i], &argv[i+1]);
      i = 0;
    }
  }
}

int main(int argc, char** argv)
{
  ft_sort(argc, argv);

  for (int j = 1; j < argc; j++)
  {
    ft_putstr(argv[j]);
    write(1, "\n", 1);
  }
}
