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
	printf("�ڡٺ��� ��ȣ ������١�\n");
	printf("��� �����Ͻðڽ��ϱ�? : ");
	count = Clotto(count);//Ƚ�� ������ �Լ�
	csave = count;//������� ���� ī��Ʈ���� ����
	while (count > 0) {
	Plotto(lotto, save, num);//�ζ� ��ȣ ���� �Լ�
	count--;


	}

	
	return 0;
}

int  Clotto(int count)
{
	count = 0;
	scanf_s("%d", &count);
	printf("%d�� �����մϴ�.\n\n", count);
	return count;
}
int Plotto(int lotto[6], int save, int num)
{
	for (int i = 0; i <= 5; i++) {
		lotto[i] = rand() % 45 + 1;//���� ���� ����
		for (int j = 0; j < i; j++) {
			if (lotto[i] == lotto[j]) {//�ߺ��� ����
				i--;
				break;
			}
		}
	}
	
	}

	for (int i = 0; i <= 5; i++) {//������ �� �迭
		for (int j = 0; j <= 4; j++) {
			if (lotto[j] > lotto[j + 1]) {
				save = lotto[j];
				lotto[j] = lotto[j + 1];
				lotto[j + 1] = save;
			}
		}
	}
	for (int i = 0; i <= 5; i++) {//��ȣ ���
		printf("%2d�� ", lotto[i]);
	}
	

	printf("\n\n");

}
