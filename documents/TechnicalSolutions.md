## Technical Solutions ##
The document show how to implement the most important features of the application.


#### Build Shear Wall from User input ####
* Build the object blocks (rectangle with hatch) at the start of command.
* using Input Prompt to get the list of points.
* Base on above list of points, create the corresponding block references (with X,Y scale).
* Create a block for those above entities (a block <== a shear wall).
* Create a reference to the shear wall block and then add to the model space (TBD - inside the current drawing or create new drawing).  


#### Split and Merge Shear Wall ####
* Should have menu/button/command to merge/split the shear wall.
* Should have menu/button/command to convert types of panel. After converting, the blocks/references should be updated/deleted/inserted
* 


#### Drag to update Shear Wall graphic ####
* User drag the edge of the panel to change its side/dimension.
* Should using Jig entity to make sample graphics when dragging.
* When drag an edge, it should affect the siblings panel



