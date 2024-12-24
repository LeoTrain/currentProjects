#include <unistd.h>

void ft_pustr(char *str)
{
  int i = 0;
  while (str[i] != '\0')
  {
    write(1, &str[i], 1);
    i++;
  }
}

int main(int argc, char** argv)
{
  for (int i = 1; i < argc; i++)
  {
    ft_pustr(argv[i]);
    write(1, "\n", 1);
  }
}
