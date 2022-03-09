# taxes

## Prerequisites

- Be sure, that on Visual Studio localdb is installed.
- In solution select multiple startup projects: TaxAPI and TaxClient.

## Possible scenarios with TaxClient app

- On the left navigation bar you could select three options: 
  - Get municipality tax rate
  - Create municipality tax rate
  - Get all municipality rates
    - When table data is loaded, by clicking on radio button on first column, you could select row, and in actions column appears two buttons: Update and Delete. By pressing Update button, record etitd form apears, and you could change values. When Delete button is pressed, question with approval buttons (Yes, No) appear.

## ToDo list with needed improvements and fixes

- Add unit test for TaxRateRepository.
- Make TaxControler actions work asynchronously.
- Split GetAllTaxRates component into separate smaller reusable components.
- Fix GetAllTaxRates component visual elements apearens/disapierens logic:
  - Radio button should disappear, when an element is deleted.
  - When Update button is pressed and Delete button is pressed after, edit form should be changed to delete massage elements and vice versa.
  - Add approprate information messages, when Update and Delete is successfully/unsuccessfully executed.
  - Maybe change logic with radio button - remove it, and on Table load add Update and Delete buttons to all rows.
 - Move DBConection string to web config instead of harcoding it in TaxAPI project.
