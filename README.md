# SportingGroupBettingService
 Betting and fixture service API
 
 To place a bet:
 1. Get all available fixtures
 2. Get the odds for the fixture you would like to bet on
 3. Construct bet component objects with the fixture ID and the odds ID
 4. Place the bet components. The server will create a single bet with the components
 
 To check a bet:
 1. Call the GetOne method on the bet controller
 
 Bet JSON Structure:
 {"id":1,"dateTimePlaced":"2022-07-31T17:45:02.116+01:00","result":1,"totalProfitLoss":0,"open":false}
