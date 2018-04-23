#Application ActionAttributeExample.Win
#Application ActionAttributeExample.Web

*Action New
!Action Postpone
*FillForm
 Subject = New task
 Deadline = 1/1/2013
*Action Save
*Action Postpone
*FillForm
 Postpone For Days = 0
*Action OK
*CheckFieldValues
 Comments = ''
*Action Postpone
*Action OK
*CheckFieldValues
 Deadline = 1/2/2013
 Comments[0] = Postponed for 1 days, new deadline is 1/2/2013
 Comments[1] = ''
*Action Postpone
*FillForm
 Postpone For Days = 3
 Comment = Sample comment text.
*Action OK
*CheckFieldValues
 Deadline = 1/5/2013
 Comments[0] = Postponed for 1 days, new deadline is 1/2/2013
 Comments[1] = ''
 Comments[2] = Postponed for 3 days, new deadline is 1/5/2013
 Comments[3] = Sample comment text.
