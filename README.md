# Simple-Image-Server
Simple image server is used to serve images for various displays. This could be browser slideshows on TVs or monitors, CPU-cooler displays, background images for Visual Studio, digital photoframes or even buttons on Stream Deck.

To get started, create "Add new list" and name the list.  
You now have a empty list. Click the list and use the "Add" button to add images.  
You do not have to copy your images, just select them and they will be served directly from their current location.  
If you click on a image in the "Elements in list", you will see a preview of the image to the right.

To use the images/test the setup, open a browser and navigate to: http://127.0.0.1:9191/[listname] where [listname] is the name of the list you just created.  
The port 9191 is standard and you can change that if you want. Just use a port you are not already using for something else..  
You should now see the first image in the list shown in your browser. If you wait a few seconds and refresh the browser it will show image number two from the list. If you hit refresh faster it will continue to show the same image for some time.
That time interval is configured under [Interval] in the [List settings] block to the left. 
The time interval can not also be sat via url parameter. Set interval=10 to overwrite the list interval and use 10 seconds instead. You can use all numbers above 0.  

If you have more than one client the currentimage/next image will be the same across all the clients. This can be a problem for some purposes and can be fixed by adding clientid to the url.
Here an example:  
http://localhost:9191/[listname]?clientid=client1  
http://localhost:9191/[listname]?clientid=bedroomimageframe

These two clients will now run independend of eachother.

If you have a client with a square screen as a cpu-cooler you can make request that the images gets cropped before they are served to a specific client. This is done with the croptosquare parameter:  
http://localhost:9191/[listname]?clientid=cpucooler&croptosquare=1  
By doing this the images will be cropped, but only for that specific client. All other clients will get the full image.

If you have a specific client with a small display you can also choose to resize the images served.
Again this is done with parameters:  
http://localhost:9191/[listname]?clientid=cpucooler&width=256  
This would give you images in original format, but with a maximum width of 256px.

If you want a default max width for all clients using a list, you can do that under [List settings] and Max width.

If you want the server to start automaticly you should click the "Enable autostart on boot" button to start the program when you log in, and check the checkbox "Autostart server".
This will make the serverprogram open in tray with the server running as soon as you turn on the computer.

The "Allow remoteaccess" makes the server accept requests that are not local. With is required for use with digital photoframes and other external devices. If you just enable it you will get an error. You have to allow the port in the firewall first.  
This is the diffirence, and also the urls that needs to be allowed.  
http://+:9191/  
http://localhost:9191/

# You can have many lists with the same name.
When the server tries to find the requested list, it starts from the top. This means that the first list with a specific name is the list it will use, but only if that list is actually active.  
If the list is inactive, it will not be used.  
A list can be inactive if you remove the "Active" flag, or because of the rules.  
In the rules you can choose a list is only active on specific weekdays or in specific timespans. This way you can have the list change during the day.  
Example:  
2 lists both called livingroomframe  
The first have an active timeperiod from 00:00 til 16:00 and the second one from 16:00 to 23:59. This way the list will change at 16:00 and the frame will now show images from the second list.  
You can have as many lists as you like.

If you do not want the serving to start from image 1 and continue down through the list, you can check the "Deliver random image". That way you will get a random image instead.

# Visual studio background
If you would like images on your background in visual studio, you can install the ClaudiaIDE extension. In the extension settings choose WebApi in the top for "Image background type", and in the bottom in the "Slideshow using webapi" enter the url and list and request json format.  
Ex: http://localhost:9191/visualstudio?format=json&clientid=visualstudio&width=3200  
In json key enter: backgroundImageUrl  
Now you will get background images served from simple image server, and if you create more lists with the same name you can again change what images you get at specific weekdays or time of day.

# Html Slideshow
If you have a old tv, a raspberry pi or other device with a browser you can choose to get the images as a html slideshow instead.
There are two templates and the url is like this:  
http://localhost:9191/visualstudio?clientid=visualstudio&format=htmltemplate01  
http://localhost:9191/visualstudio?clientid=visualstudio&format=htmltemplate02

htmltemplate01 fades between images and htmltempalte02 changes without fade, but has a frame.
You can use the other parameters here aswell:  
http://localhost:9191/visualstudio?clientid=visualstudio&format=htmltemplate01&width=256&croptosquare=1  
The above url would give you a html slideshow with images not wider than 256 pixel and cropped to squares.

# Settings
The settings are saved in json and you can open the folder to backup your settings by clicking the "Open settings folder" button.
Settings are written on close so if you make large changes you might want to hit the "Save settings now" button just in case..

