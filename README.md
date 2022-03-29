# taxes

## Prerequisites

- Be sure, that on Visual Studio localdb is installed.
- In solution select multiple startup projects: TaxAPI and TaxClient.

## Possible scenarios with TaxClient app

- On the left navigation bar you could select three options: 
  - Get municipality tax rate
  - Create municipality tax rate
  - Get all municipality rates
    - When table data is loaded, all rows have **Update** and **Delete** buttons. When **Update** is pressed, the editing form with changeable values is loaded. When **Delete** is pressed, an approval message appears.

## ToDo list with needed improvements and fixes

- Add unit test for TaxRateRepository.
- Make TaxControler actions work asynchronously.
- **[Done]** Split GetAllTaxRates component into separate smaller reusable components.
- Fix GetAllTaxRates component visual elements apearens/disapierens logic:
  - ~~Radio button should disappear, when an element is deleted.~~
  - When Update button is pressed and Delete button is pressed after, edit form should be changed to delete massage elements and vice versa.
  - Add approprate information messages, when Update and Delete is successfully/unsuccessfully executed.
  - **[Done]** Maybe change logic with radio button - remove it, and on Table load add Update and Delete buttons to all rows.
 -  **[Done]** Move DBConection string to web config instead of harcoding it in TaxAPI project.
