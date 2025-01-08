# depth first traversal

Depth First Traversal (or Depth First Search) explores a graph by going as deep as possible along each branch before backtracking.
It uses a stack implicitly (via recursion) or explicitly (by managing a stack data structure yourself).

The basic procedure is:

1. Pick a starting node and mark it as visited.
2. Move to an unvisited adjacent node, mark it visited, and repeat the process recursively.
3. When all adjacent nodes of the current node have been visited, backtrack to the previous node and continue.

dft uses a stack to keep track of the nodes to be visited. we are adding from the top of the stack and removing from the top of the stack.



# breadth first traversal

Breadth First Traversal (or Breadth First Search) explores a graph by visiting all the nodes at the current depth level before moving on to nodes at the next depth level.

It uses a queue to keep track of the nodes to be visited. we are adding from the back of the queue and removing from the front of the queue.

