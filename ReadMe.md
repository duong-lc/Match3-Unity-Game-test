Question 1:
add object pool that supports multiple types of prefab (cell prefab, normalItem prefab, bonusItem prefab)
add singleton to classes that needs accessed frequently by other instances
add move fish sprites to resources and load them from there

Advantages: project's architecture is clear to read and understand. Great use dependency injection of manager classes. Great use of interface for UI elements.

Disadvantages: Uses similar prefabs, can use prefab variants instead. Can use dynamic batching for normalItem prefabs. Cells can be static batches to reduce draw calls. for example, All Cells can be 1 geometry pass and 1 material pass, making them only take 2 draw calls. Same thing with similar sprite normalItem prefabs.

suggestions: A lot of times, you iterate through the entire board to find empty cell. Instead of this, on cell's item is assigned to null, add them to a list that tracks empty cells. So when you need to grab empty cells specifically, you'd just grab them directly.