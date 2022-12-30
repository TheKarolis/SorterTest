# SorterTest
Web API for comparing the performance of bubble and selection sort algorithms

How to use:
For in order to generate requests Postman software could be used

**Sorting**

**Bubble**
1) Run project
2) On Postman select post method
3) Write into the uri: "https://localhost:****/bubble", where **** is the port number shown when running     project web browser starts.
4) Select Raw and JSON option for the body
5) Write in data into the body. Sample data: {
  "Value":"1,9,5,6,4,7,21,18,98,111,499,2"
}
Response contains sorted numbers.

**Bubble**
1) Run project
2) On Postman select post method
3) Write into the uri: "https://localhost:****/SelectionSort", where **** is the port number shown when running     project web browser starts.
4) Select Raw and JSON option for the body
5) Write in data into the body. Sample data: {
  "Value":"1,9,5,6,4,7,21,18,98,111,499,2"
}
Response contains sorted numbers.

Sorting results are also saved into files BubbleSortResult.txt and SelectionSortResult.txt

**Last results**

**Last Bubble**
1) Run project
2) Select get method
3) Write into the uri: "https://localhost:****/lastBubble", where **** is the port number shown when running     project web browser starts.

Response contains sorted numbers.

**Last Selection Sort**
1) Run project
2) Select get method
3) Write into the uri: "https://localhost:****/lastSelectionSort", where **** is the port number shown when running     project web browser starts.

Response contains last sorted numbers.

**Performance test**

1) Run project
2) On Postman select post method
3) Write into the uri: "https://localhost:****/Performance", where **** is the port number shown when running     project web browser starts.
4) Select Raw and JSON option for the body
5) Write in data into the body. Bigger ample data (for numbers to be high enought to show a difference): 

{"Value":"75, 576, 802, 445, 950, 184, 789, 723, 427, 999, 549, 887, 176, 752, 79, 472, 585, 29, 224, 854, 203, 373, 313, 660, 637, 27, 864, 874, 761, 519, 30, 396, 938, 492, 775, 534, 179, 430, 891, 827, 144, 812, 911, 469, 817, 227, 778, 619, 935, 747, 616, 152, 865, 501, 770, 663, 568, 573, 579, 286, 882, 959, 868, 98, 254, 988, 487, 525, 784, 917, 855, 828, 800, 35, 125, 187, 852, 810, 932, 244, 561, 991, 302, 394, 253, 220, 726, 113, 564, 267, 964, 815, 198, 849, 276, 120, 516, 968, 348, 354, 598, 758, 625, 100, 180, 217, 740, 550, 365, 133, 375, 644, 16, 166, 924, 97, 755, 745, 921, 674, 650, 528, 14, 858, 39, 67, 685, 698, 160, 773, 278, 693, 434, 423, 446, 803, 599, 33, 341, 840, 62, 781, 345, 192, 524, 233, 135, 556, 700, 390, 371, 541, 8, 604, 114, 818, 208, 380, 256, 293, 869, 536, 965, 382, 542, 406, 419, 612, 763, 508, 204, 664, 225, 397, 412, 68, 859, 998, 262, 364, 779, 898, 291, 69, 414, 841, 684, 863, 86, 819, 60, 557, 59, 95, 175, 481, 329, 181, 578, 131, 681, 570, 689, 315, 916, 555, 686, 195, 359, 962, 443, 421, 997, 54, 883, 70, 826, 558, 127, 952, 84, 49, 732, 200, 132, 465, 949, 571, 128, 383, 351, 772, 115, 657, 787, 958, 266, 4, 455, 790, 605, 705, 258, 844, 123, 475, 851, 538, 324, 103, 978, 743, 48, 795, 990, 961, 908, 207, 670, 608, 117, 316, 385, 147, 360, 594, 595, 522, 648, 881, 141, 527, 273, 450, 101, 283, 237, 940, 435, 242, 80, 981, 691, 970, 309, 995, 809, 223, 259, 310, 963, 292, 848, 530, 12, 994, 485, 173, 845, 647, 532, 918, 733, 326, 177, 871, 575, 158, 589, 304, 878, 338, 742, 669, 334, 424, 330, 629, 567, 539, 410, 140, 493, 613, 196, 820, 735, 92, 897, 901, 946, 299, 457, 440, 96, 545, 432, 690, 577, 640, 824, 295, 395, 168, 520, 728, 928, 821, 983, 551, 452, 618, 400, 484, 673, 582, 13, 727, 645, 593, 235, 145, 955, 106, 398, 194, 408, 405, 167, 497, 662, 384, 20, 285, 927, 895, 943, 22, 294, 847, 993, 531, 956, 343, 588, 894, 102, 641, 26, 554, 44, 498, 52, 388, 134, 458, 638, 142, 331, 10, 43, 399, 31, 971, 257, 336, 264, 796, 915, 107, 402, 526, 737, 282, 722, 303, 280, 713, 709, 126, 418, 708, 552, 468, 413, 358, 379, 467, 967, 695, 678, 715, 37, 829, 627, 502, 702, 202, 438, 507, 40, 45, 215, 213, 162, 255, 839, 129, 937,"}

Response contains algorithm names and the time it took them to perform.
