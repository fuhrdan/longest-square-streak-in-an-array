//*****************************************************************************
//** 2501. Longest Square Streak in an Array    leetcode                     **
//*****************************************************************************


int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

bool contains(int *set, int size, long long value) {
    int low = 0, high = size - 1;
    while (low <= high) {
        int mid = low + (high - low) / 2;
        if (set[mid] == value) {
            return true;
        } else if (set[mid] < value) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return false;
}

int longestSquareStreak(int* nums, int numsSize) {
    // Step 1: Sort the array for ordered subsequences
    qsort(nums, numsSize, sizeof(int), compare);

    int maxStreak = 0;

    // Step 2: Iterate over each number in the sorted array
    for (int i = 0; i < numsSize; i++) {
        int currentStreak = 1;
        long long currentNum = nums[i];

        // Check for the square streak
        while (currentNum <= LLONG_MAX / currentNum && contains(nums, numsSize, currentNum * currentNum)) {
            currentNum = currentNum * currentNum;
            currentStreak++;
        }

        // Update max streak if we found a longer one
        if (currentStreak >= 2) {
            if (currentStreak > maxStreak) {
                maxStreak = currentStreak;
            }
        }
    }

    // Step 3: Return result
    return maxStreak >= 2 ? maxStreak : -1;
}