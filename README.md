# QuickPrefabs

QuickPrefabs is a productivity tool for Unity developers, designed to simplify and speed up the process of finding and selecting GameObjects in your Unity projects. This custom editor window allows for quick access to frequently used prefabs and scene objects, enhancing workflow efficiency.

## Features

- Custom Unity Editor Window
- Persistent prefab list using ScriptableObjects
- Drag-and-drop functionality for adding prefabs
- Quick selection of objects in the scene or project
- Reorderable list for easy management of prefabs
- Automatic saving of changes
- Support for both scene objects and project assets

## Installation

1. Clone the repository or download the ZIP file:


git clone https://github.com/yourusername/QuickPrefabs.git




2. Copy the `QuickPrefabs` folder into your Unity project's `Assets` directory.

3. Ensure all scripts are in the correct location within your Unity project.

## Usage

1. Open the QuickPrefabs window by navigating to `Window > Quick Prefabs` in the Unity menu.

2. To add a prefab or scene object:
   - Drag and drop the object from your Project window or Hierarchy into the QuickPrefabs list.
   - Alternatively, use the '+' button at the bottom of the list to add a new entry, then assign an object using the object field.

3. To select an object:
   - Click the "Select" button next to the object in the list.
   - If the object is in the scene, it will be selected in the Hierarchy.
   - If it's a prefab, it will be selected in the Project window.

4. To reorder the list:
   - Use the drag handles on the left side of each entry to reorder items.

5. To remove an item:
   - Use the '-' button at the bottom of the list when an item is selected.

## Configuration

- The prefab list data is stored in a ScriptableObject located at `Assets/MSCreativeTech/QuickPrefabs/PrefabListData.asset`.
- This file is automatically created if it doesn't exist when the QuickPrefabs window is opened for the first time.

## Troubleshooting

- If prefabs are not appearing in the list, ensure that the `PrefabListData.asset` file exists and is not corrupted.
- For scene objects that are not being found, check if they are active in the scene and not hidden by Unity's built-in hiding mechanisms.

## Contributing

Contributions to QuickPrefabs are welcome! Please feel free to submit a Pull Request or open an Issue for any bugs or feature requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Unity Technologies for the powerful Unity Editor API
- The Unity community for inspiration and support in creating editor tools
