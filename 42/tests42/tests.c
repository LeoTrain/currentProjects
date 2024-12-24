#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>

void ft_putchar(char c);
void ft_putstr(char *str);
void ft_putnbr(int nbr);
int ft_iterative_factorial(int nb);
int ft_recursive_factorial(int nb);
int ft_iterative_power(int nb, int power);
int ft_recursive_power(int nb, int power);
int ft_fibonacci(int index);
int ft_sqrt(int nb);
int ft_is_prime(int nb);
int ft_find_next_prime(int nb);
int ft_ten_queens_puzzle(void);
char *ft_strdup(char *src);
int *ft_range(int min, int max);
int ft_ultimate_range(int **range, int min, int max);
char *ft_strjoin(int size, char **strs, char *sep);

void testStrjoin(void)
{
    int size = 2;
    char **strs = NULL;
    strs[0] = "Leo";
    strs[1] = "Berto";
    char *sep = " ";
    char *result = ft_strjoin(size, strs, sep);
    ft_putstr(result);
}

void testUltimateRange(void)
{
    int *range = NULL;
    int size = ft_ultimate_range(&range, 0, 5);

    if (size > 0)
    {
        printf("Generated table (size = %d) :\n", size);
        for (int i = 0; i < size; i++)
            printf("%d ", range[i]);
        printf("\n");
        free(range);
    }
    else if (size == 0)
        printf("Min >= Max, empty table.\n");
    else
        printf("Memory allocation error");
}

void display_int_array(int *array, int size)
{
    for (int i = 0; i < size; i++)
    {
        ft_putnbr(array[i]);
    }
    write(1, "\n", 1);
}

void testRange(void)
{
    int *range = ft_range(0, 5);
    display_int_array(range, 5);
    display_int_array(ft_range(5, 10), 5);
    display_int_array(ft_range(6, 10), 4);
    display_int_array(ft_range(5, 5), 0);
}

void testStrdup(void)
{
    char *src = "abcdef";
    char *new = ft_strdup(src);
    ft_putstr(src);
    ft_putchar('\n');
    ft_putstr(new);
}

void testFindNextPrime(void)
{
  for (int i = 0; i < 20; i++)
  {
    ft_putnbr(ft_find_next_prime(i));
    ft_putchar('\n');
  }
}

void testIsPrime(void)
{
  for (int i = 0; i < 20; i++)
  {
    ft_putnbr(ft_is_prime(i));
    ft_putchar('\n');
  }
}

void testSqrt(void)
{
  ft_putnbr(ft_sqrt(1));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(2));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(3));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(4));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(5));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(6));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(7));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(8));
  ft_putchar('\n');
  ft_putnbr(ft_sqrt(9));
  ft_putchar('\n');
}

void testFibonacci(void)
{
  ft_putnbr(ft_fibonacci(0));
  ft_putchar('\n');
  ft_putnbr(ft_fibonacci(1));
  ft_putchar('\n');
  ft_putnbr(ft_fibonacci(2));
  ft_putchar('\n');
  ft_putnbr(ft_fibonacci(3));
  ft_putchar('\n');
  ft_putnbr(ft_fibonacci(4));
  ft_putchar('\n');
  ft_putnbr(ft_fibonacci(15));
  ft_putchar('\n');
}

void testRecursivePower(void)
{
  ft_putnbr(ft_recursive_power(1, -2));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_power(0, 2));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_power(3, 0));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_power(2, 2));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_power(2, 4));
  ft_putchar('\n');
}

void testIterativePower(void)
{
  ft_putnbr(ft_iterative_power(1, -2));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_power(0, 2));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_power(3, 0));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_power(2, 2));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_power(2, 4));
  ft_putchar('\n');
}


void testIterativeFactorial(void)
{
  ft_putnbr(ft_iterative_factorial(-3));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_factorial(0));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_factorial(2));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_factorial(3));
  ft_putchar('\n');
  ft_putnbr(ft_iterative_factorial(4));
  ft_putchar('\n');
}

void testRecursiveFactorial(void)
{
  ft_putnbr(ft_recursive_factorial(-3));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_factorial(0));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_factorial(2));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_factorial(3));
  ft_putchar('\n');
  ft_putnbr(ft_recursive_factorial(4));
  ft_putchar('\n');
}


int main()
{
  /* testIterativeFactorial(); */
  /* testRecursiveFactorial(); */
  /* testIterativePower(); */
  /* testRecursivePower(); */
  /* testFibonacci(); */
  /* testSqrt(); */
  /* testIsPrime(); */
  /* testFindNextPrime(); */
  /*ft_ten_queens_puzzle();*/
    /*testStrdup();*/
    /*testRange();*/
    /*testUltimateRange();*/
    testStrjoin();
}

