#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>

int main(int argc, char* argv[]) {

char str_tmp[1024];
char* p;
int b[3] = { 0,0,0 };
int cnt, sum, i;

FILE* pFile = NULL;

pFile = fopen("lotto.txt", "r");
if (pFile != NULL)
{
    while (!feof(pFile)) { //do
        fgets(str_tmp, 30, pFile);
        printf( "%s", str_tmp );

      //  cnt = 0;
      //  sum = 0;
      //  p = strtok(str_tmp, ",");
       // while (p != NULL) {
      //      b[cnt] = atoi(p);
     //       cnt++;
          //  p = strtok(NULL, ",");
     //   }
     //   for (i = 0; i < cnt; i++) {
      //      sum += b[i];
    //        printf("%d ", b[i]);
   //     }
    //    printf("토큰수 : %d , 합 : %d\n", cnt, sum);
    }
}
fclose(pFile);

return 0;
}