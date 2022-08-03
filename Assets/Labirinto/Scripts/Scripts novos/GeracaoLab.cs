using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeracaoLab : MonoBehaviour
{
    // Codigo feito pelo Dannylo em Python


    /*import random


# Norte, Oeste, Sul, Leste -> 1,1,1,1
def listsum(input_list):
    my_sum = 0
    for k in input_list:
        my_sum += sum(k)
    return my_sum


def list_bintoint(input_list) :
    returner = list(input_list)
    temp_string = ''
    for c in range(0, len(input_list)) :
        temp_string = temp_string + str(input_list[c])
    my_bin_int = int (temp_string, 2)
    return my_bin_int


class MazeMatrix :
    def __init__(self, size):
        self.holder = None
        self.result = []
        self.size = size

    def generate(self):
        walls = [[[1, 1, 1, 1] for i in range(self.size)] for j in range(self.size)]
        a = 0
        b = 0
        visit_total = 0
        atmnode = [a, b]
    visited = [[0 for i in range(self.size)] for j in range(self.size)]
        visited[a][b] = 1
        visitn = [[a, b]]
        c = 0
        while visit_total != (self.size** 2):
            f_01 = [0, 0, 0, 0]
            if a != 0:
                if visited[b][a - 1] == 0:
                    f_01[0] = 1
            if b != self.size - 1:
                if visited[b + 1][a] == 0:
                    f_01[1] = 1
            if a != self.size - 1:
                if visited[b][a + 1] == 0:
                    f_01[2] = 1
            if b != 0:
                if visited[b - 1][a] == 0:
                    f_01[3] = 1
            if f_01 == [0, 0, 0, 0]:
                atmnode = visitn[c - 1]
                a = atmnode[0]
                b = atmnode[1]
                c = c - 1
            else:
                node_found = False
                while node_found == False:
                    randomer = random.randint(0, 3)
                    if f_01[randomer] == 1:
                        if randomer == 0:
                            opposite_node = [atmnode[0] - 1, atmnode[1]]
                            walls[atmnode[1]][atmnode[0]][0] = 0
                            walls[opposite_node[1]][opposite_node[0]][2] = 0
                        elif randomer == 1:
                            opposite_node = [atmnode[0], atmnode[1] + 1]
                            walls[atmnode[1]][atmnode[0]][1] = 0
                            walls[opposite_node[1]][opposite_node[0]][3] = 0
                        elif randomer == 2:
                            opposite_node = [atmnode[0] + 1, atmnode[1]]
                            walls[atmnode[1]][atmnode[0]][0] = 0
                            walls[opposite_node[1]][opposite_node[0]][0] = 0
                        else:
                            opposite_node = [atmnode[0], atmnode[1] - 1]
                            walls[atmnode[1]][atmnode[0]][3] = 0
                            walls[opposite_node[1]][opposite_node[0]][1] = 0
                        c = c + 1
                        visitn.insert(c, opposite_node)
                        atmnode = opposite_node
                        visited[atmnode[1]][atmnode[0]] = 1
                        a = atmnode[0]
                        b = atmnode[1]
                        node_found = True
            visit_total = listsum(visited)
            self.holder = walls

    def convert(self) :
        row_builder = []
        for counter in range(0, len(self.holder)) :
            col_builder = []
            for second_counter in range(0, len(self.holder)) :
                col_builder.append(list_bintoint(self.holder[counter][second_counter]))
            row_builder.append(col_builder)
        self.result = row_builder


mazetest = MazeMatrix(16)
mazetest.generate()
mazetest.convert()
for c in range(0, len(mazetest.result)):
    print(mazetest.result[c])
        */
}
