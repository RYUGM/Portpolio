#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int Plotto(int lotto[6], int save, int num);
int  Clotto(int count);
int main(void)
{
	srand(time(NULL));
	int lotto[6] = { 0, };
	int count = 0;
	int save = 0;
	int num = 0;
	int re = 0;
	int csave = 0;
	printf("★☆복권 번호 생성기☆★\n");
	printf("몇번 발행하시겠습니까? : ");
	count = Clotto(count);//횟수 지정용 함수
	csave = count;//재출력을 위해 카운트값을 저장
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
	for (int i = 0; i <= 5; i++) {
		lotto[i] = rand() % 45 + 1;//랜덤 난수 생성
		for (int j = 0; j < i; j++) {
			if (lotto[i] == lotto[j]) {//중복수 제거
				i--;
				break;
			}
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
	for (int i = 0; i <= 5; i++) {//번호 출력
		printf("%2d번 ", lotto[i]);
	}
	

	printf("\n\n");

}
