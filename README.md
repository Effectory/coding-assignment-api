# Employee Feedback Survey API - Coding Assignment

## Business Context

You're building an API for an employee feedback survey system (with a couple of endpoints for reporting & management purposes). 
Employees from different departments participate in anonymous surveys to provide feedback about their work experience and organizational culture.

## Business Requirements

### Survey Participation
- **Participants**: Employees belong to one of four departments: `Marketing`, `Sales`, `Development`, or `Reception`
- **Fair Participation**: Each employee can only submit their responses once per survey to ensure data integrity
- **Authentication**: The system should identify participants (via mock user ID) while maintaining response anonymity

### Survey Management
- **Question Delivery**: The API should serve survey questions with their available answer options
- **Response Collection**: Employees submit their answers through the API
- **Survey Lifecycle**: Surveys have an open/closed state

### Reporting & Analytics
- **Anonymous Reporting**: Results must be completely anonymous - no way to trace responses back to individuals
- **Department-Level Insights**: Calculate statistics (min, max, average) per department for each question
- **Data Protection**: Results are only calculated when the survey closes to prevent partial data from compromising anonymity

## Technical Requirements

Your API should support:

1. **Question Retrieval**
   - Get survey questions and answer options
   - Support pagination for better performance
   - Handle multilingual content (Dutch/English)

2. **Response Submission**
   - Accept employee responses with participant identification
   - Validate department assignments
   - Enforce one-response-per-participant rule
   - Handle both Likert scale and open-text responses

3. **Results Calculation**
   - Calculate min, max, and average scores per department
   - Only allow calculations when survey is closed
   - Ensure sufficient response volume for anonymity

4. **Survey State Management**
   - Track survey open/closed status
   - Prevent responses when survey is closed
   - Enable results calculation only after closure

In the above, think about the frontend that would be consuming your API, you don't need to build it.

## Data Structure

Use the provided `questionnaire.json` as the data. 

## Technical Expectations

- Create a test suite covering business rules and discovered edge cases
- Implement proper error handling and validation
- Consider data persistence (in-memory is acceptable for this assignment)
- Document your API endpoints (Swagger/OpenAPI)
- Include clear setup and run instructions

## Time Investment

**Please limit yourself to 4 hours maximum.** 

Focus on:
1. Core business logic implementation
2. Essential API endpoints
3. Key business rule enforcement
4. Basic test coverage

## Questions to Consider

When implementing, consider these aspects and document your assumptions:
- How will you ensure response anonymity while preventing duplicate submissions?
- What constitutes "sufficient data" for anonymous reporting?
- How should the system handle incomplete responses?
- What validation rules apply to different question types?
- How will you structure the data model for efficient querying?

## Tech Stack Recommendation

While you're free to choose any technology, we recommend staying close to our current stack for better evaluation:
- **Backend**: >= .NET8/ C#
- **Cloud**: Azure services
- **Testing**: xUnit, NSubstitute

Learn more about our complete tech stack at [tech.effectory.com](https://tech.effectory.com/#what-are-we-working-on).

## Deliverables

1. Working API that builds and runs without errors
2. Test suite demonstrating correctness
3. Brief documentation explaining:
   - Your interpretation of the requirements
   - Key assumptions made
   - Design decisions and trade-offs
   - What you would implement next given more time

## Evaluation Criteria

We'll assess:
- **Business Logic**: How well you've translated requirements into code
- **Code Quality**: Readability, structure, and best practices
- **Problem Solving**: Your approach to handling the constraints and requirements
- **Communication**: How clearly you explain your solution and reasoning

Remember: This assignment is a conversation starter, not a final product. 

Focus on demonstrating your thought process and technical approach rather than building a production-ready system.