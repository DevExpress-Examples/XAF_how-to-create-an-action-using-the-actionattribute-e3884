#Application ActionAttributeExample.Win
#Application ActionAttributeExample.Web

*Action New
*FillForm
 Subject = New task
 Is Completed = False
*Action Save
*Action Complete
*CheckFieldValues
 Is Completed = True
!Action Complete
