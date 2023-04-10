
// SPDX-License-Identifier: GPL-3.0

pragma solidity >=0.7.0 <0.9.0;

contract UnityGameData {

    mapping(address => Player) public Players;
    mapping(address => mapping(string => Games)) public GameIdentities;
    mapping(address => mapping(int => Games)) public GameNamesbyID;
    mapping(address => mapping(string => mapping(int => GameScore))) public GameScores;

    

    mapping(address => mapping(string =>mapping(int => Player))) public ClassPlayers; 
    mapping(address => mapping(string => DifferentClasses)) public Classes;
    mapping(address => mapping(int => DifferentClasses)) public ClassesID;
    mapping(address => Instructor) public Instructors;
    

    // Structs and Arrays to store student data

    struct Player {
        string name;
        string class;
        string age;
        address Instructoraddress;
        address Playeraddress;
        int classid;
    }

    struct Instructor {
        string name;
        address Instructoraddress;
        string age;
        int numberofclasses;
        int numberofGamesCreated;   
    }
    

    struct DifferentClasses {
        string classname;
        int playercount;
        int id;
    }
   
   struct Games {
        string Gamename;
        int GameID;
        int NumberofScores;
    }

    //Structs and Arrays to store specific student gamescores

    struct GameScore {
        int id;
        int score;
        string date;
        string time;
        string scoredata;
        //score for qn1
        //score for qn2
        
    }
    

    // Login function to check if an address is either in the student of teachers structs.
    function Login(address username) public view returns (string memory x) {

        if (Instructors[username].Instructoraddress == address (0) ){
            if (Players[username].Playeraddress == address (0) ){
                x = "Not registered";   
                return x;
            } else {
                x = "Student is registered";
                return x;
            }
            
        } else {
            x = "Teacher is registered";
            return x;
        }
    }
    
    //updating student structs 
    function addPlayer (
        string memory _name,
        string memory _classname,
        string memory _age,
        address _Instructor
        ) public {
        
        int count = Classes[_Instructor][_classname].playercount;
        int newcount = count + 1;
        Classes[_Instructor][_classname].playercount = newcount;

        Player memory newPlayer = Player(_name, _classname, _age, _Instructor, msg.sender,newcount);

        ClassPlayers[_Instructor][_classname][newcount] = newPlayer;

        Players[msg.sender] = newPlayer;    
    }
    

    function getPlayer(
        address username,
        uint x
    ) public view returns(string memory y) {
        if (x == 1){
            y = Players[username].name;
        } else if(x == 2){
            y = Players[username].class;
            } else if(x == 3){
                y= Players[username].age;
                } 
        return y;
    }


    
    function addInstructor (
        string memory _name,
        string memory _age
    ) public {
        Instructor memory newInstructor = Instructor(_name, msg.sender, _age,0,0);
        Instructors[msg.sender] = newInstructor;
    }

    function getInstructor(
        address username,
        uint x
        ) public view returns(string memory y) {
        
        if (x == 1){
            y = Instructors[username].name;
        } else if(x == 2){
            y = Instructors[username].age;
            } 

        return y;
        
    }    
    
    function addClass (
        string memory _classname
    ) public returns (int x) {
        //require(useraddress to be inside Teacher struct

        require(bytes(_classname).length > 0, "Class name cannot be empty");

        string memory ClassStatus = Classes[msg.sender][_classname].classname;
        
        bytes32 classHash = keccak256(abi.encodePacked(_classname));
        bytes32 classStatusHash = keccak256(abi.encodePacked(ClassStatus));

        if(classStatusHash == classHash){
            x = 2;
            //Students[useraddress].studentaddress == address (0)
        }
        else{
            
            int Count = Instructors[msg.sender].numberofclasses;
            int newCount = Count + 1;
            Instructors[msg.sender].numberofclasses = newCount;
            
            DifferentClasses memory newClass = DifferentClasses(_classname, 0,newCount);
            ClassesID[msg.sender][newCount] = newClass;
            Classes[msg.sender][_classname] = newClass;
            x= 1;
        } 
    }

    function InstructorcheckClass (
        address username,
        string memory _classname
    ) public view returns(int x) {
        
        require(bytes(_classname).length > 0, "Class name cannot be empty");

        string memory ClassStatus = Classes[username][_classname].classname;
        bytes32 classHash = keccak256(abi.encodePacked(_classname));
        bytes32 classStatusHash = keccak256(abi.encodePacked(ClassStatus));

        if(classStatusHash == classHash){
            x = 2; // "Class is already registered";
        }
       else{
           x= 1; // "Class not registered";
       }
    }

    function getPlayersInstructorAddress(
        address username
    ) public view returns(address y) {
        y = Players[username].Instructoraddress;
        return y;
    }

    function getInstructorsClassCount(
        address username
    ) public view returns(int y) {
        y= Instructors[username].numberofclasses;
        return y;
    }  

    function InstructorgetClassbyID(
        address username,
        int _classid
    ) public view returns(string memory) {
        return ClassesID[username][_classid].classname;
    }


    function getClassPlayerCount(
        address username,
        string memory _classname

    ) public view returns(int y) {
        y= Classes[username][_classname].playercount;
        return y;
    }

    function getClassPlayer(
        address username,
        string memory _classname,
        int _classid
    ) public view returns(address) {
        require( username == ClassPlayers[username][_classname][_classid].Instructoraddress, "You are not the teacher");

        return ClassPlayers[username][_classname][_classid].Playeraddress;
    }


    
    function addGamename (
        string memory _Gamename
        ) public returns(int x){
            require(bytes(_Gamename).length > 0, "Game Name cannot be empty");

            string memory GameStatus = GameIdentities[msg.sender][_Gamename].Gamename;
            bytes32 GameHash = keccak256(abi.encodePacked(_Gamename));
            bytes32 GameStatusHash = keccak256(abi.encodePacked(GameStatus));

            if(GameStatusHash == GameHash){

                x = 2; // "Game is already registered";
            }
            else
            {
                x= 1; // "Game is not registered";

                int count = Instructors[msg.sender].numberofGamesCreated;
                int newCount = count + 1;
                Instructors[msg.sender].numberofGamesCreated = newCount;

                Games memory newGame = Games(_Gamename,newCount,0);
                GameIdentities[msg.sender][_Gamename] = newGame; 
                GameNamesbyID[msg.sender][newCount] = newGame;
            }
    }

    function InstructorcheckGamename(
        address username,
        string memory _Gamename
    ) public view returns(int x){

        require(bytes(_Gamename).length > 0, "Game Name cannot be empty");

        string memory GameStatus = GameIdentities[username][_Gamename].Gamename;
        
        bytes32 GameHash = keccak256(abi.encodePacked(_Gamename));
        bytes32 GameStatusHash = keccak256(abi.encodePacked(GameStatus));

        if(GameStatusHash == GameHash){

            x = 2; // "Game is already registered";
            
        }
       else{
           x= 1; // "Game is not registered";
       }
    }

    function PlayercheckGamename(
        address username,
        string memory _Gamename
    ) public view returns(int x){

        require(bytes(_Gamename).length > 0, "Game Name cannot be empty");

        address Instructoraddress = Players[username].Instructoraddress;
        string memory GameStatus = GameIdentities[Instructoraddress][_Gamename].Gamename;
        bytes32 GameHash = keccak256(abi.encodePacked(_Gamename));
        bytes32 GameStatusHash = keccak256(abi.encodePacked(GameStatus));

        if(GameStatusHash == GameHash){
            x = 2; // "Game is already registered"; 
        }
       else{
           x= 1; // "Game is not registered";
       }
    }
    
        
    function getInstructorsGamesCreatedCount(
        address username
    ) public view returns(int y) {
        y= Instructors[username].numberofGamesCreated;
        return y;
    }

    function getInstructorGameNamebyID(
        address username,
        int _id
    ) public view returns(string memory y) {
        y= GameNamesbyID[username][_id].Gamename;
        return y;
    }
    
    function PlayergetGameNamesbyID(
        address username,
        int _id
    ) public view returns(string memory y) {
        address Instructoraddress = Players[username].Instructoraddress;
        y= GameNamesbyID[Instructoraddress][_id].Gamename;
        return y;
    }     


    // updating specific students gamescore structs and arrays
    function addGameScore (
        string memory Gameidentity,
        int _score,
        string memory _date,
        string memory _time,
        string memory _scoredata
        ) public {
            
            int Count = GameIdentities[msg.sender][Gameidentity].NumberofScores;
            int newCount = Count + 1;
            GameIdentities[msg.sender][Gameidentity].NumberofScores = newCount;

            GameScore memory newGameScore = GameScore(newCount,_score, _date, _time,_scoredata);
            GameScores[msg.sender][Gameidentity][newCount] = newGameScore;
            //GameScoreArray.push(newGameScore);

    }




    function getGameScoreCounts(
        address username,
        string memory Gameidentity
    ) public view returns (int) {
        return GameIdentities[username][Gameidentity].NumberofScores;
    }

    function getGameScoreID (
        address username,
        string memory Gameidentity, 
        int _id
    ) public view returns (int) {
        return GameScores[username][Gameidentity][_id].id;
    }
    
    function getGameScoreScore (
        address username,
        string memory Gameidentity, 
        int _id
    ) public view returns (int) {
        return GameScores[username][Gameidentity][_id].score;
    }    

    function getGameScoreDate (
        address username,
        string memory Gameidentity, 
        int _id
    ) public view returns (string memory) {
        return GameScores[username][Gameidentity][_id].date;
    }

    function getGameScoreTime (
        address username,
        string memory Gameidentity, 
        int _id
    ) public view returns (string memory) {
        return GameScores[username][Gameidentity][_id].time;
    }
    
    function getGameScoreData (
        address username,
        string memory Gameidentity, 
        int _id
    ) public view returns (string memory) {
        return GameScores[username][Gameidentity][_id].scoredata;
    }

    
    function InstructorgetGameScoreCounts(
        address username,
        address playeraddress,
        string memory Gameidentity
    ) public view returns (int) {
        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameIdentities[playeraddress][Gameidentity].NumberofScores;
    }

    function InstructorgetGameScoreID (
        address username,
        address playeraddress,
        string memory Gameidentity, 
        int _id
        ) public view returns (int) {

        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameScores[playeraddress][Gameidentity][_id].id;
    }
    
    function InstructorgetGameScoreScore (
        address username,
        address playeraddress,
        string memory Gameidentity, 
        int _id
        ) public view returns (int) {

        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameScores[playeraddress][Gameidentity][_id].score;
    }

    function InstructorgetGameScoreDate (
        address username,
        address playeraddress,
        string memory Gameidentity, 
        int _id
        ) public view returns (string memory) {

        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameScores[playeraddress][Gameidentity][_id].date;
    }

    function InstructorgetGameScoreTime (
        address username,
        address playeraddress,
        string memory Gameidentity, 
        int _id
        ) public view returns (string memory) {

        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameScores[playeraddress][Gameidentity][_id].time; 
    }
    

        function InstructorgetGameScoreData (
        address username,
        address playeraddress,
        string memory Gameidentity, 
        int _id
        ) public view returns (string memory) {

        require( username == Players[playeraddress].Instructoraddress,"You are not the teacher!");
        return GameScores[playeraddress][Gameidentity][_id].scoredata;
    }
    
}