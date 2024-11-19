void ft_swap(int *a, int *b)
{
    int swap = *a;
    *a = *b;
    *b = swap;
}


void ft_sort_int_tab(int *tab, int size)
{
    for (int i = 0; i < size - 1; i++)
    {
        if (tab[i] > tab[i+1])
        {
            ft_swap(&tab[i], &tab[i+1]);
            i = -1;
        }
    }
}
