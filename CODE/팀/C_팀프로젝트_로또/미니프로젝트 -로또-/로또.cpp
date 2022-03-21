#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>
int Plotto(int lotto[6], int save, int num);
int  Clotto(int count);

int main(int argc, char* argv[])
{
	srand(time(NULL));
	int lotto[6] = { 0, };
	int count = 0;
	int save = 0;
	int num = 0;
	printf("★☆복권 번호 생성기☆★\n");
	printf("몇번 발행하시겠습니까? : ");
	count = Clotto(count);//횟수 지정용 함수
	while (count > 0) {
		Plotto(lotto, save, num);//로또 번호 생성 함수
		count--;
	}


	return 0;
}
int  Clotto(int count)
{
	count = 0;
	scanf_s("%d", &count);
	printf("%d번 발행합니다.\n\n", count);
	return count;
}
int Plotto(int lotto[6], int save, int num)
{
	
	int bestnum[][6] = { 13,23,26,31,35,43,
5,7,13,20,21,44,
27,36,37,41,43,45,
3,13,16,23,24,35,
7,11,16,21,27,33,
1,7,15,32,34,42,
2,9,10,14,22,44,
4,12,14,25,35,37,
7,8,9,17,22,24,
1,2,11,16,39,44,
22,26,31,37,41,42,
3,6,17,23,37,39,
2,6,17,18,21,26,
9,11,16,21,28,36,
3,9,10,29,40,45,
2,5,12,14,24,39,
1,6,13,37,38,40,
1,21,25,29,34,37,
2,13,25,28,29,36,
6,21,36,38,39,43,
6,12,19,23,34,42,
1,18,28,31,34,43,
11,20,29,31,33,42,
2,18,24,30,32,45,
1,14,15,24,40,41,
2,9,10,16,35,37,
4,15,24,35,36,40,
10,11,20,21,25,41,
4,9,23,26,29,33,
1,9,26,28,30,41,
7,9,22,27,37,42,
4,12,22,24,33,41,
2,12,30,31,39,43,
3,4,15,22,28,40,
14,21,35,36,40,44
	};
	for (int i = 0; i <= 5; i++) {
		lotto[i] = rand() % 45 + 1;//랜덤 난수 생성
		for (int j = 0; j < i; j++) {
			if (lotto[i] == lotto[j]) {//중복수 제거
				i--;
				break;
			}
		}
	}

	for (int i = 0; i <= 5; i++) {//오름차 순 배열
		for (int j = 0; j <= 4; j++) {
			if (lotto[j] > lotto[j + 1]) {
				save = lotto[j];
				lotto[j] = lotto[j + 1];
				lotto[j + 1] = save;
			}
		}
	}
	
	for (int j = 0; j <= 983; j++){

		for (int i = 0; i <= 5; i++) {//번호 출력
			




			if (lotto[i] == bestnum[j][i])

				printf("%2d번(%d회차 중복)", lotto[i], j);


		}
		
	}


	printf("\n\n");
	return 0;
}