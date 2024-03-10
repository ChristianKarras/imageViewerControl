## General

A class for viewing 2 dimensional data sets of type double, Complex or Uint16. 

The viewer is desinged as a controll for windows forms
 
The purpose is to have an easy control for viewing (simple) images after certain states of data processing. Hence the image viewer in its current version only supports greyscale images
Control of the image (such as scaling linear / log or and so on can be done via a context menu on the image

## Prerequisites for the Project:
Scottplot is required to make the imageviewer work. It can be installed to the project via NuGet Package manager or downloaded here:  https://scottplot.net/quickstart/winforms/
Licence of ScottPlot is MIT


## Structure of this project
This project contains the imageViewerControl as well as a test class for the image viewer (Windows forms element that hosts image viewer control)

* imageViewerControl.cs  Controll element
* Form1.cs Test class for the image viewer

## Pulic Members and Methods
For interaction with the program the follwoing funcitons and members of the control are public:
    
## Methods:
   # setImage 
   sets the image data set
   
   # getImage 
   gets the displayed image as bitmap (with or wihout overlays
    
   # saveImage 
   Save the image to a file
   # setDisplayThresholds 
   Externally set the values at which the image will be clipped? (values below will be black or highligted, above are white or highlighted
   # removeDisplayThresholds 
   Remove externally set display thresholds
   # rescale 
   rescale the dynamic range of the image to display image range in 256 grey levels between black and white 

## Members:
   # pixelSizeInUmX 
   Set the pixelsize of the image to micro meter
   # pixelSizeRatioYbX  
   if x and y do have different pixel sizes, you can set the ratio here (default is 1, so same pixelsizes)
    
   # pointOverlays, rectOverlays, ellipseOverlays: 
   these will be shown as overlays in the image
   # parameters 
   struct that contains the major parameters of the displayed image as well as the raw data 
   
   
