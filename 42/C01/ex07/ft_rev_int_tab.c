void ft_swap(int *a, int *b)
{
    int swap = *a;
    *a = *b;
    *b = swap;
}

void ft_rev_int_tab(int *tab, int size)
{
    for (int i = 0; i < size / 2; i++)
    {
        ft_swap(&tab[i], &tab[size - 1 -i]);
    }
}
