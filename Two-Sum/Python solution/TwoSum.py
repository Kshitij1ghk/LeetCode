class Solution:
    def twoSum(self,nums:list[int],target:int)-> list[int]:
        hashmap={}
        for i,val in enumerate(nums):
            compliment=target-val
            if compliment in hashmap:
                return [hashmap[compliment],i]
            hashmap[val]=i
        return []

# enumerate gives both index and value directly 
## so here val acts as nums[i] nothing else 