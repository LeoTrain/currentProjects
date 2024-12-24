CC = gcc
CFLAGS = -Wall -Wextra -Werror
SRC = tests.c ../solutions42/C00/ex00/ft_putchar.c ../solutions42/C01/ex05/ft_putstr.c \
			  ../solutions42/C00/ex07/ft_putnbr.c ../solutions42/C05/ex00/ft_iterative_factorial.c \
			  ../solutions42/C05/ex01/ft_recursive_factorial.c ../solutions42/C05/ex02/ft_iterative_power.c \
			  ../solutions42/C05/ex03/ft_recursive_power.c ../solutions42/C05/ex04/ft_fibonacci.c \
			  ../solutions42/C05/ex05/ft_sqrt.c ../solutions42/C05/ex06/ft_is_prime.c \
			  ../solutions42/C05/ex07/ft_find_next_prime.c ../solutions42/C05/ex08/ft_ten_queens_puzzle.c \
			  ../solutions42/C07/ex00/ft_strdup.c ../solutions42/C07/ex01/ft_range.c \
			  ../solutions42/C07/ex02/ft_ultimate_range.c ../solutions42/C07/ex03/ft_strjoin.c
OBJ = $(SRC:.c=.o)

all: test

test: $(OBJ)
	$(CC) $(CFLAGS) -o test $(OBJ)

%.o: %.c
	$(CC) $(CFLAGS) -o $@ -c $<

clean:
	rm -rf $(OBJ)

fclean: clean
	rm -rf test

re: fclean all run

run:
	./test

