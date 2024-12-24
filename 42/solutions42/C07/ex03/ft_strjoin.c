#include <stdlib.h>

int mystrlen(char *str)
{
    int i = 0;
    while (str[i] != 0)
        i++;
    return i;
}

char *ft_strjoin(int size, char **strs, char *sep)
{
    int i = 0;
    int j = 0;

    if (size == 0)
    {
        char *empty = (char *)malloc(1);
        if (!empty)
            return NULL;
        empty[0] = '\0';
        return empty;
    }
    
    int sep_len = mystrlen(sep);
    int full_size = 0;

    for (int i = 0; i < size; i++)
    {
        full_size += mystrlen(strs[i]);
      if (i < size - 1)
            full_size += sep_len;
    }

    for (i = 0; i < size; i++)
    {
        full_size += mystrlen(strs[i]);
        full_size += mystrlen(sep);
    }

    char *final_string = (char*)malloc(full_size + 1 * 1); 
    int current_index = 0;
    for (i = 0; i < size; i++)
    {
        for (j = 0; j < mystrlen(strs[i]); j++)
        {
            final_string[current_index] = strs[i][j];
            current_index++;
        }
        for (j = 0; j < mystrlen(sep); j++)
        {
            final_string[current_index] = sep[j];
            current_index++;
        }
    }
    final_string[current_index] = '\0';
    return final_string;
}
