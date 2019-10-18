let input, button, greeting;
let str = "";
let str_arr = [];
let font;
let isStarted = false;

function preload() {
  font = loadFont("Lobster-Regular.ttf"); // load the font. MAKE SURE TO ADD THIS FONT FILE TO THE FILES TAB TO THE RIGHT
}

function setup() {
	noLoop(); // do not call draw(). we don't want to draw until a sentence is submitted
	
	// Canvas
	createCanvas(windowWidth, windowHeight, WEBGL); // create a WEBGL 3d canvas
	background(0,0,0); // set background color to solid black

	// Input Box
  input = createInput();  // create an input box
  input.position(20, 65);  // position the box to the top left
	
	// Button
  button = createButton('add'); // sets the text shown within the button
  button.position(input.x + input.width, 65); // sets the position of the button
  button.mousePressed(showSentence); // when the button is pressed, call the showSentence() function defined below
	
	// Question Sentence
  greeting = createElement('h2', 'Type in any sentence:'); // this sets the content of the question sentence
  greeting.position(20, 5); // this sets the position of the question sentence
	greeting.style("color : white"); // this sets the color of the question sentence on top left
	greeting.style("font : Lobster-Regular");
	
	// set text attributes
  textAlign(CENTER);
  textSize(50);
	
}

function draw() {
	if (isStarted == true) {  // only draw if we say so
		background(0,0,0); // sets the background color of the 3d space
		orbitControl(); // allows mouse drag around the space
	
		// for each text we have, we want to first update its position by .update(), then display it on the screen by .display().
		for (let i = 0; i < str_arr.length; i++) {
			str_arr[i].update();
			str_arr[i].display();
		}
	}
}

function showSentence() {
  greeting.html("Add more sentences: "); // once first sentence is submitted, change the question sentence to this.
	isStarted = true; // start the drawing process
	loop(); // enable draw() function 
	
	// get the input sentence and split it by spaces. 
	str = input.value();
	let strs = str.split(" ");
	
	// set a random grayscale color for this sentence. 
	// All characters in this sentence will have the same color, but a new added sentence will have different colors to differentiate
	let randomColor = random(30,100);
	
	// IF YOU WANT TO USE RGB COLOR INSTEAD OF GRAYSCALE, DO THE FOLLOWING:
	// comment out line 63, 75, 93-100
	// uncomment line 68, 76, 82-91 (to uncomment 82-91, remove the /* and */ in line 82 and 91)
	//let randomColor = createVector(random(0,255),random(0,255),random(0,255));
	
	// loop through each word in the sentence and create Type object with random x,y position and fixed z position (to ensure same starting z pos)
  for (let i = 0; i < strs.length*20; i++) {
    let x = random(-width / 2, width / 2);
    let y = random(-height / 2, height / 2);
    let z = random(-width*5, width/2);
    str_arr.push(new Type(strs[i%strs.length], x, y, z, randomColor));
		//str_arr.push(new Type(strs[i%strs.length], x, y, z, randomColor.x, randomColor.y, randomColor.z));
	}
	input.value('');
}

class Type {
	/*
  constructor(_str, _x, _y, _z, r,g,b) {
		background(255,255,255);
    this.str = _str;
    this.x = _x;
    this.y = _y;
    this.z = _z;
		this.color = color(r,g,b);
  }
	*/
	
	constructor(_str, _x, _y, _z, grayscale) {
		background(255,255,255);
    this.str = _str;
    this.x = _x;
    this.y = _y;
    this.z = _z;
		this.color = color(grayscale);
  }
	
	// move the text in the z direction
  update() {
    this.z += 10;
    if(this.z > width/2){
    	this.z = -width*5;
    }
  }
	
	// draw the text in following fashion
  display() {
    push();
    translate(this.x, this.y, this.z);
    textAlign(CENTER, CENTER);
    textFont(font);
    textSize(100);
		fill(this.color);
    text(this.str, 0, 0);
    pop();
  }
}