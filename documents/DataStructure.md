## Data Structure ##
This documents describe how the objects are organized in the *.dwg drawing database and how to map them to C# object.

#### List of object types in the drawing ####
* ShearPanel
* Door
* Window
* NormalWall

Each of above objects are graphically represented in the drawing as a rectangle with hatch pattern (texture) inside. (TBD the actual hatch pattern for each type).

#### How to structure the objects in the drawing ####
* Each type of object should have a associated block ( and will be created if they haven't not been created already when run the command). The block should define the rectangle (or lines - TBD) and the hatch patterns. Other information like type, guid, width, height, .. should be stored in xref and then attach to the block.
* Each instance of object should have a associated block reference, which is referenced to the corresponding block. The block references contain the scale (X,Y) information so they appears with different size in the drawing. Also should have xref with information attach to the block reference.
* The group of all above instances construct a shear wall. A shear wall should be a block and then there's a block reference refer to it. The actual graphic of the shear wall is rendered by the block reference. Should be there xref attach to the block and the reference if needed.
* The drawing is constructed by many ShearWall references, each one is created by running the command (TBD).

####  Classes Design ####
<!-- language: lang-none -->
                    +-----------+              
         +----------> WallPanel <---------+    
         |          +--^----^---+         |    
         |             |    |             |    
         |             |    |             |    
    +----+-----+  +----+ +--+----+ +------+---+
    |ShearPanel|  |Door| |Window | |NormalWall|
    +----------+  +----+ +-------+ +----------+

	ShearWall:List<WallPanel> wallPanels
Each object should contain the corresponding BlockReference and BlockRecord

#### Technical Requirement ####
* All xrefs and xrecords should have versioning mechanism.
* Keyword TBD
* Every object in the drawing should have GUID (TBC - not sure)


